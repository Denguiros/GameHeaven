using Microsoft.AspNetCore.Http;

namespace GameHeaven.Dtos.FranchiseDtos
{
    public class CreateFranchiseDto
    {
        public string Name { get; set; }
        public IFormFile Cover { get; set; }
    }
}
