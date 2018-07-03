﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NoodleApi.Models
{
    public class Noodle
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }
        public long BrandId { get; set; }
        public string Flavor { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }
    }
}
