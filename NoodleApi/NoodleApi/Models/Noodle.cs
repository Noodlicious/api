using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoodleApi.Models
{
    public class Noodle
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Brand { get; set; }
        public string Flavor { get; set; }
        public string ImgUrl { get; set; }
    }
}
