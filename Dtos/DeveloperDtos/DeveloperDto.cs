using GameHeaven.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameHeaven.Dtos.DeveloperDtos
{
    public class DeveloperDto : ViewModelBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IdentityUser User { get; set; }
        [DisplayName("Cover")]
        public string CoverPath { get; set; }
        public string Description { get; set; }
        public string WebsiteLink { get; set; }
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }

    }
}
