using GameHeaven.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameHeaven.Dtos.PublisherDtos
{
    public class PublisherDto : ViewModelBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IdentityUser User { get; set; }
        public string CoverPath { get; set; }
        public string Description { get; set; }
        public string WebsiteLink { get; set; }
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
    }
}
