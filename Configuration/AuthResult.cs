using GameHeaven.ViewModels;
using GameHeaven.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace GameHeaven.Configuration
{
    public class AuthResult : ViewModelBase
    {
        public string Token { get; set; }
        public User User { get; set; }
    }
}
