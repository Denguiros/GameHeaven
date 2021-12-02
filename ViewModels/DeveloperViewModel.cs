using GameHeaven.Dtos.DeveloperDtos;
using GameHeaven.Dtos.PublisherDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GameHeaven.ViewModels
{
    public class DeveloperViewModel
    {
        public CreateDeveloperDto CreateDeveloper { get; set; }
        public UpdateDeveloperDto UpdateDeveloper { get; set; }
        public IEnumerable<SelectListItem> Users { get; set; }
    }
}
