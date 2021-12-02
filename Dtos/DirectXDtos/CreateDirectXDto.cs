using System.ComponentModel.DataAnnotations;
namespace GameHeaven.Dtos.DirectXDtos
{
    public class CreateDirectXDto
    {
        [Required]
        public string Name { get; set; }
    }
}
