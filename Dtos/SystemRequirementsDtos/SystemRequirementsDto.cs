using GameHeaven.Dtos.CPUDtos;
using GameHeaven.Dtos.DirectXDtos;
using GameHeaven.Dtos.GPUDtos;
using GameHeaven.Dtos.OsDtos;

namespace GameHeaven.Dtos.SystemRequirementsDtos
{
    public class SystemRequirementsDto
    {
        public int Id { get; set; }
        public int Storage { get; set; }
        public OsDto Os { get; set; }
        public GPUDto GPU { get; set; }
        public CPUDto CPU { get; set; }
        public DirectXDto DirectX { get; set; }
        public int Ram { get; set; }
        public string AdditionalNotes { get; set; }
    }
}
