using GameHeaven.Dtos.DeveloperDtos;
using GameHeaven.Dtos.PublisherDtos;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel;

namespace GameHeaven.Entities
{
    public class User 
    {
        public IdentityUser UserProperties { get; set; }
        [DisplayName("Publisher")]
        public PublisherDto Publisher { get; set; }
        [DisplayName("Developer")]
        public DeveloperDto Developer { get; set; }
        [DisplayName("Roles")]
        public IList<string> Roles { get; set; }
    }
}
