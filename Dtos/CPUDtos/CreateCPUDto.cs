﻿using System.ComponentModel.DataAnnotations;
namespace GameHeaven.Dtos.CPUDtos
{
    public class CreateCPUDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
