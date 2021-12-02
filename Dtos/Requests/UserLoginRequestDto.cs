using GameHeaven.ViewModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameHeaven.Dtos.Requests
{
    public class UserLoginRequestDto : ViewModelBase
    {
        [Required]
        [EmailAddress]
        public string Email { get; set;}
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set;}
    }
}
