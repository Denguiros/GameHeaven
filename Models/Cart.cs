using GameHeaven.Dtos.GameDtos;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace GameHeaven.Models
{
    public class Cart
    {
        public IdentityUser User { get; set; }
        public List<GameDto> Games { get; set; }
    }
}
