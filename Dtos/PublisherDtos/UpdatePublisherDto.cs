using GameHeaven.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameHeaven.Dtos.PublisherDtos
{
    public class UpdatePublisherDto : ViewModelBase
    {

        [StringLength(30, MinimumLength = 3, ErrorMessage = "Maximum 30 characters")]
        public string Name { get; set; }
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Maximum 30 characters")]
        public string Description { get; set; }
        public IFormFile Cover { get; set; }
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Maximum 30 characters")]
        public string WebsiteLink { get; set; }
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Maximum 30 characters")]
        public string FacebookLink { get; set; }
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Maximum 30 characters")]
        public string TwitterLink { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
