using GameHeaven.Dtos.PaymentDto;
using GameHeaven.Entities;
using GameHeaven.Models;
using GameHeaven.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace GameHeaven.Controllers
{
    public class PaymentController : Controller
    {

        public async Task<IActionResult> AddPayment()
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            var cart = await Request<Cart>.GetAsync(APILinks.CART_URL + "/" + HttpContext.Session.GetObject<ApplicationUser>("User").UserProperties.Id, token: token);
            double amount = 0;
            cart.Games.ForEach(game =>
            {
                amount += game.Price;
            });
            CreatePaymentDto paymentDto = new()
            {
                PayerId = HttpContext.Session.GetObject<ApplicationUser>("User").UserProperties.Id,
                GamesIds = cart.Games.Select(game => game.Id).ToList(),
                Amount = (int)amount,
            };
            var jsonObject = JsonConvert.SerializeObject(paymentDto);
            var paymentId = await Request<AddPaymentResponseDto>.PostAsync(APILinks.PAYMENT_URL, jsonObject, token: token);
            return Ok(paymentId);
        }
        
        public async Task<IActionResult> ApprovePayment(int paymentId)
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            var jsonObject = JsonConvert.SerializeObject(new { paymentId = paymentId });
            var x = await Request<ViewModelBase>.PostAsync(APILinks.PAYMENT_URL+"/PaymentDone", jsonObject, token: token);
            return Ok(x);
        }
    }
}
