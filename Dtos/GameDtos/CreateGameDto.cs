﻿using GameHeaven.Dtos.SystemRequirementsDtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameHeaven.Dtos.GameDtos
{
    public class CreateGameDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        public DateTime? ReleaseDate { get; set; }
        [Required]
        public int PublisherId { get; set; }
        [Required]
        public int StatusId { get; set; }
        [Required]
        public IList<int> PlatformIds { get; set; }
        [Required]
        public IFormFile Cover { get; set; }
        [Required]
        public IList<IFormFile> Images { get; set; }
        [Required]
        public IList<IFormFile> Videos { get; set; }
        [Required]
        public IList<int> GenresIds { get; set; }
        public int? FranchiseId { get; set; }
        public CreateSystemRequirementsDto? RecommendedSystemRequirements { get; set; }
        public CreateSystemRequirementsDto? MinimumSystemRequirements { get; set; }
        public IList<int>? DeveloperIds { get; set; }

    }
}
