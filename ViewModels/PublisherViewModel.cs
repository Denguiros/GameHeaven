using GameHeaven.Dtos.PublisherDtos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GameHeaven.ViewModels
{
    public class PublisherViewModel
    {
        public CreatePublisherDto CreatePublisher { get; set; }
        public UpdatePublisherDto UpdatePublisher { get; set; }
        public IEnumerable<SelectListItem> Users { get; set; }
    }
}
