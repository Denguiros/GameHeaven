using System.ComponentModel.DataAnnotations;
namespace GameHeaven.Dtos.OsDtos
{
    public class CreateOsDto
    {
        [Required]
        public string Name { get; set; }
    }
}
