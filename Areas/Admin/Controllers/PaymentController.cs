using GameHeaven.Dtos.DeveloperDtos;
using GameHeaven.Dtos.PaymentDto;
using GameHeaven.Dtos.PublisherDtos;
using GameHeaven.Entities;
using GameHeaven.Models;
using GameHeaven.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameHeaven.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PaymentController : Controller
    {
        // GET: PaymentController
        public async Task<ActionResult> Index()
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            var payments = await Request<List<PaymentDto>>.GetAsync(APILinks.PAYMENT_URL, token);
            return View(payments);
        }
    }
}
