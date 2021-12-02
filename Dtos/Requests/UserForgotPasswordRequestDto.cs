using GameHeaven.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace GameHeaven.Dtos.Requests
{
    public class UserForgotPasswordRequestDto : ViewModelBase
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Config { get; set; } // used to send mail with server adress and controller name and action name
    }
}
