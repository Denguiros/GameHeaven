using GameHeaven.Dtos.DeveloperDtos;
using GameHeaven.Dtos.GameDtos;
using GameHeaven.Dtos.PublisherDtos;
using GameHeaven.Models;
using GameHeaven.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel;

namespace GameHeaven.Entities
{
    public class UserViewModel : ViewModelBase
    {
        public ApplicationUser UserProperties { get; set; }
        [DisplayName("Publisher")]
        public PublisherDto Publisher { get; set; }
        [DisplayName("Developer")]
        public DeveloperDto Developer { get; set; }
        [DisplayName("Roles")]
        public IList<string> Roles { get; set; }
        public IList<GameDto> OwnedGames { get; set; }


    }
}
