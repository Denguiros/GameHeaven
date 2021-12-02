using GameHeaven.Dtos.DeveloperDtos;
using GameHeaven.Dtos.FranchiseDtos;
using GameHeaven.Dtos.GenreDtos;
using GameHeaven.Dtos.PlatformDtos;
using GameHeaven.Dtos.PublisherDtos;
using GameHeaven.Dtos.StatusDtos;
using GameHeaven.Dtos.SystemRequirementsDtos;
using GameHeaven.ViewModels;
using System;
using System.Collections.Generic;

namespace GameHeaven.Dtos.GameDtos
{
    public class GameDto : ViewModelBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public float Discount { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public StatusDto Status { get; set; }
        public bool Approved { get; set; }
        public string ImagesPath { get; set; }
        public string CoverPath { get; set; }
        public string VideosPath { get; set; }
        public IList<DeveloperDto> Developers { get; set; }
        public PublisherDto Publisher { get; set; }
        public IList<GenreDto> Genres { get; set; }
        public IList<PlatformDto> Platforms { get; set; }
        public FranchiseDto Franchise { get; set; }
        public SystemRequirementsDto RecommendedSystemRequirements { get; set; }
        public SystemRequirementsDto MinimumSystemRequirements { get; set; }

    }
}