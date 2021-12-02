using GameHeaven.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GameHeaven.ViewModels
{
    public class UserViewModel
    {
        public User User { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}
