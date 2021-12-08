using GameHeaven.Dtos.GameDtos;
using GameHeaven.Dtos.PublisherDtos;
using GameHeaven.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GameHeaven.ViewModels
{
    public class AdminUserViewModel : ViewModelBase
    {
        public Entities.UserViewModel User { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }
        public List<GameDto> OwnedGames { get; set; }
    }
}
