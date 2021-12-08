using System.Collections.Generic;
using GameHeaven.Dtos.UserDtos;
using GameHeaven.Dtos.Requests;
using GameHeaven.Models;
using GameHeaven.Dtos;

namespace GameHeaven.ViewModels
{
    public class ViewModelBase
    {
        public bool Success { get; set; }
        public IList<string> Errors { get; set; }
        public IList<string> Messages { get; set; }
        public UserRegistrationDto UserRegistrationDto { get; set; }
        public UserLoginRequestDto UserLoginRequestDto { get; set; }
        public Cart Cart { get; set; }
        public UserForgotPasswordRequestDto UserForgotPasswordRequestDto { get; set; }
        public string PaymentProcessor { get; set; }
        public object Dai { get; set; }
        public UpdateUserDto UpdateUserDto { get; set; }
    }
}
