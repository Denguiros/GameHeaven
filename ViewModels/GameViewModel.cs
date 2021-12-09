using GameHeaven.Dtos.DeveloperDtos;
using GameHeaven.Dtos.GameDtos;
using GameHeaven.Dtos.PublisherDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GameHeaven.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        public CreateGameDto CreateGame { get; set; }
        public UpdateGameDto UpdateGameDto { get; set; }
        public IEnumerable<SelectListItem> DeveloperSelectItems { get; set; }
        public IEnumerable<SelectListItem> PublisherSelectItems { get; set; }
        public IEnumerable<SelectListItem> StatusesSelectItems { get; set; }
        public IEnumerable<SelectListItem> PlatformsSelectItems { get; set; }
        public IEnumerable<SelectListItem> GenresSelectItems { get; set; }
        public IEnumerable<SelectListItem> FranchisesSelectItems { get; set; }
        public IEnumerable<SelectListItem> MinOsesSelectItems { get; set; }
        public IEnumerable<SelectListItem> MinGPUsSelectItems { get; set; }
        public IEnumerable<SelectListItem> MinCPUsSelectItems { get; set; }
        public IEnumerable<SelectListItem> MinDirectXsSelectItems { get; set; }
        public IEnumerable<SelectListItem> RecOsesSelectItems { get; set; }
        public IEnumerable<SelectListItem> RecGPUsSelectItems { get; set; }
        public IEnumerable<SelectListItem> RecCPUsSelectItems { get; set; }
        public IEnumerable<SelectListItem> RecDirectXsSelectItems { get; set; }
    }
}
