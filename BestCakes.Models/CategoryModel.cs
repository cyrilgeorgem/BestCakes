﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BestCakes.Models
{
    public class CategoryModel
    {
        public CategoryModel()
        {
            Name = "";
            Description = "";
        }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
