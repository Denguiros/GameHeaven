using GameHeaven.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace GameHeaven.Controllers
{
    public class CartController : Controller
    {

        [HttpGet]
        public async Task<ActionResult> GetCart()
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            var cart = await Request<Cart>.GetAsync(APILinks.CART_URL + "/" + HttpContext.Session.GetString("UserId"), token: token);
            return Ok(cart);
        }

        // POST: CartController/Add
        [HttpPost]
        public async Task<ActionResult> Add(int gameId)
        {
            UpdateCart cart = new()
            {
                UserId = HttpContext.Session.GetString("UserId"),
                GameId = gameId
            };
            var jsonObject = JsonConvert.SerializeObject(cart);
            var token = Request.Cookies[Constants.JWT.ToString()];
            var updatedCart = await Request<Cart>.PostAsync(APILinks.CART_URL, jsonObject, token: token);
            return Ok(updatedCart);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int gameId)
        {
            UpdateCart cart = new()
            {
                UserId = HttpContext.Session.GetString("UserId"),
                GameId = gameId
            };
            var jsonObject = JsonConvert.SerializeObject(cart);
            var token = Request.Cookies[Constants.JWT.ToString()];
            var updatedCart = await Request<Cart>.PostAsync(APILinks.CART_URL+"/RemoveFromCart", jsonObject, token: token);
            return Ok(updatedCart);
        }

    }
}
