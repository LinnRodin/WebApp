﻿using WebApp.Models.Entities;

namespace WebApp.ViewModels
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }

        public int? CategoryId { get; set; }
        public CategoryEntity? Category { get; set; }

        public List<GridCollectionItemViewModel> RelatedDetailsList { get; set; } = new List<GridCollectionItemViewModel>();

    }
}