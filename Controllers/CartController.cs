using GameHeaven.Entities;
using GameHeaven.Models;
using GameHeaven.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameHeaven.Controllers
{
    public class CartController : Controller
    {

        [HttpGet]
        public async Task<ActionResult> GetCart()
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            var cart = await Request<Cart>.GetAsync(APILinks.CART_URL + "/" + HttpContext.Session.GetObject<Entities.UserViewModel>("User").UserProperties.Id, token: token);
            return Ok(cart);
        }

        // POST: CartController/Add
        [HttpPost]
        public async Task<ActionResult> Add(int gameId)
        {
            if (HttpContext.Session.GetObject<Entities.UserViewModel>("User") is null)
            {
                return base.Ok(new ViewModelBase
                {
                    Errors = new List<string>()
                    {
                        "Please login first"
                    }
                });
            }
            UpdateCart cart = new()
            {
                UserId = HttpContext.Session.GetObject<Entities.UserViewModel>("User").UserProperties.Id,
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
                UserId = HttpContext.Session.GetObject<Entities.UserViewModel>("User").UserProperties.Id,
                GameId = gameId
            };
            var jsonObject = JsonConvert.SerializeObject(cart);
            var token = Request.Cookies[Constants.JWT.ToString()];
            var updatedCart = await Request<Cart>.PostAsync(APILinks.CART_URL + "/RemoveFromCart", jsonObject, token: token);
            return Ok(updatedCart);
        }

    }
}
