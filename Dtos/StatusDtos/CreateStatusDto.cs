using GameHeaven.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace GameHeaven.Dtos.StatusDtos
{
    public class CreateStatusDto : ViewModelBase
    {
        [Required]
        public string Name { get; set; }
    }
}
