﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystem.Model
{
    public class Product
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string ReorderLevel { get; set; }

        public string Description { get; set; }

        public Category category { get; set; }
    }
}
