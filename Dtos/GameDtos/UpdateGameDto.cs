using GameHeaven.Dtos.DeveloperDtos;
using GameHeaven.Dtos.FranchiseDtos;
using GameHeaven.Dtos.GenreDtos;
using GameHeaven.Dtos.PlatformDtos;
using GameHeaven.Dtos.PublisherDtos;
using GameHeaven.Dtos.StatusDtos;
using GameHeaven.Dtos.SystemRequirementsDtos;

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameHeaven.Dtos.GameDtos
{
    public class UpdateGameDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public float? Discount { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? PublisherId { get; set; }
        public int StatusId { get; set; }
        public IFormFile Cover { get; set; }
        public IList<IFormFile> Images { get; set; }
        public IList<IFormFile> Videos { get; set; }
        public IList<int> PlatformIds { get; set; }
        public IList<int> GenresIds { get; set; }
        public int? FranchiseId { get; set; }
        public UpdateSystemRequirementsDto? UpdatedRecommendedSystemRequirements { get; set; }
        public UpdateSystemRequirementsDto? UpdatedMinimumSystemRequirements { get; set; }
        public IList<int>? DeveloperIds { get; set; }
        public StatusDto Status { get; set; }
        public IList<DeveloperDto> Developers { get; set; }
        public PublisherDto Publisher { get; set; }
        public IList<GenreDto> Genres { get; set; }
        public IList<PlatformDto> Platforms { get; set; }
        public FranchiseDto Franchise { get; set; }
        public SystemRequirementsDto RecommendedSystemRequirements { get; set; }
        public SystemRequirementsDto MinimumSystemRequirements { get; set; }
    }
}
