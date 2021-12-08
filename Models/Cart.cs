using GameHeaven.Dtos.GameDtos;
using GameHeaven.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace GameHeaven.Models
{
    public class Cart : ViewModelBase
    {
        public IdentityUser User { get; set; }
        public List<GameDto> Games { get; set; }
    }
}
