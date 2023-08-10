﻿namespace FreeCources.Services.Catalog.Dtos
{
    public class CourceUpdateDto
    {
        public string  Id{ get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string UserId { get; set; }
        public string Picture { get; set; }
        public FeatureDto Feature { get; set; }
        public string CategoryId { get; set; }
    }
}