﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestCakes.Models
{
    public class ItemModel
    {
        public ItemModel()
        {
            Name = "";
            Description = "";
            ImageUrl = "";
        }
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal OfferPrice { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
