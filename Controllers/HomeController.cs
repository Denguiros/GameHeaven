using GameHeaven.Dtos.GameDtos;
using GameHeaven.Dtos.Requests;
using GameHeaven.Models;
using GameHeaven.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHeaven.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _appEnvironment;
        public HomeController(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var viewModel = new HomeViewModel();
            viewModel.Games = await Request<List<GameDto>>.GetAsync(APILinks.GAME_URL);
            viewModel.Dai = JsonConvert.DeserializeObject<object>(System.IO.File.ReadAllText(_appEnvironment.WebRootPath+"/js/src/contracts/Dai.json"));
            viewModel.PaymentProcessor = System.IO.File.ReadAllText(_appEnvironment.WebRootPath+"/js/src/contracts/PaymentProcessor.json");
            viewModel.Games.ForEach(x =>
            {
                StringBuilder str = new StringBuilder("");
                var imgs = x.ImagesPath.Split(",").ToList();
                imgs.ForEach(img => {
                    str.Append(img.Trim(new Char[] { '[', '"', ']' }));
                    str.Append(",");
                    });
                x.ImagesPath = str.ToString();
            });
            if (TempData["ViewModelBase"] is not null)
            {
                var viewModelBase = JsonConvert.DeserializeObject<ViewModelBase>(TempData["ViewModelBase"].ToString());
                viewModel.Errors = viewModelBase.Errors;
                viewModel.Messages = viewModelBase.Messages;
                viewModel.Success = viewModelBase.Success;
                viewModel.UserLoginRequestDto = viewModelBase.UserLoginRequestDto;
                viewModel.UserForgotPasswordRequestDto = viewModelBase.UserForgotPasswordRequestDto;
                viewModel.UserRegistrationDto = viewModelBase.UserRegistrationDto;
            }
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
