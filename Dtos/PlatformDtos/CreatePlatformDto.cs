using System.ComponentModel.DataAnnotations;

namespace GameHeaven.Dtos.PlatformDtos
{
    public class CreatePlatformDto
    {
        [Required]
        public string Name { get; set; }
    }
}
