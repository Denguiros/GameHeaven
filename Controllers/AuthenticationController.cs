using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Http;
using GameHeaven.Dtos.UserDtos;
using GameHeaven.Configuration;
using GameHeaven.Dtos.Requests;
using GameHeaven.ViewModels;
using System.Web;

namespace GameHeaven.Controllers
{
    [Route("[controller]")]
    public class AuthenticationController : Controller
    {

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegistrationDto userRegistrationDto)
        {
            if (ModelState.IsValid)
            {
                userRegistrationDto.Config = "https://localhost:5003/Authentication/ConfirmEmail";
                string jsonObject = JsonConvert.SerializeObject(userRegistrationDto);
                var registerResult = await Request<ViewModelBase>.PostAsync(APILinks.REGISTER_URL, jsonObject);
                if (registerResult.Success)
                {
                    TempData["ViewModelBase"] = JsonConvert.SerializeObject(registerResult);
                    return RedirectToAction("Index","Home");
                }
                userRegistrationDto.Errors = registerResult.Errors;
                return View(userRegistrationDto);
            }
            return View(userRegistrationDto);
        }
        [HttpPost]
        [Route("Login")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Login(UserLoginRequestDto userLoginRequestDto)
        {
            if (ModelState.IsValid)
            {
                string jsonObject = JsonConvert.SerializeObject(userLoginRequestDto);
                var authResult = await Request<AuthResult>.PostAsync(APILinks.LOGIN_URL, jsonObject);
                if (authResult.Success)
                {
                    CookieOptions cookie = new();
                    cookie.HttpOnly = true;
                    cookie.Expires = System.DateTimeOffset.Now.AddHours(6);
                    Response.Cookies.Append(Constants.JWT.ToString(), authResult.Token, cookie);
                    TempData["ViewModelBase"] = JsonConvert.SerializeObject(authResult);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    userLoginRequestDto.Errors = authResult.Errors;
                    return View(userLoginRequestDto);
                }
            }
            return View(userLoginRequestDto);
        }

        [HttpGet]
        [Route("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmailAsync(string token, string email)
        {
            var encodedToken = HttpUtility.UrlEncode(token);
            var link = APILinks.CONFIRM_EMAIL + $"?token={encodedToken}&email={email}";
            var result = await Request<APIRequest>.GetAsync(link);
            TempData["ViewModelBase"] = JsonConvert.SerializeObject(result);
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [Route("Forgot-Password")]
        public async Task<IActionResult> ForgotPassword(UserForgotPasswordRequestDto userForgotPasswordRequestDto)
        {
            if (ModelState.IsValid)
            {
                userForgotPasswordRequestDto.Config = "https://localhost:5003/Authentication/ResetPassword";
                string jsonObject = JsonConvert.SerializeObject(userForgotPasswordRequestDto);
                var result = await Request<UserDto>.PostAsync(APILinks.FORGOT_PASSWORD, jsonObject);
                if(result.Success)
                {
                    TempData["ViewModelBase"] = JsonConvert.SerializeObject(result);
                    return RedirectToAction("Index", "Home");
                }
                userForgotPasswordRequestDto.Errors = result.Errors;
                return View(userForgotPasswordRequestDto);
            }
            return View(userForgotPasswordRequestDto);
        }
        [HttpGet]
        [Route("ResetPassword")]
        public IActionResult ResetPassword(string token, string email)
        {

            UserResetPasswordRequestDto userResetPasswordRequestDto = new()
            {
                Email = email,
                Token = token
            };
            return View(userResetPasswordRequestDto);
        }
        [HttpPost]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword(UserResetPasswordRequestDto resetPasswordRequestDto)
        {
            if (ModelState.IsValid)
            {
                string jsonObject = JsonConvert.SerializeObject(resetPasswordRequestDto);
                var result = await Request<UserDto>.PostAsync(APILinks.RESET_PASSWORD, jsonObject);
                if(result.Success)
                {
                    TempData["ViewModelBase"] = JsonConvert.SerializeObject(result);
                    return RedirectToAction("Index", "Home");
                }
                resetPasswordRequestDto.Errors = result.Errors;
                return View(resetPasswordRequestDto);
            }
            return View(resetPasswordRequestDto);
        }


    }
}
