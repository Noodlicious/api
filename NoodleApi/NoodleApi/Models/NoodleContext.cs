using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NoodleApi.Models
{
    public class NoodleContext : DbContext
    {
        public NoodleContext(DbContextOptions<NoodleContext> options) : base(options)
        {

        }

        public DbSet<Noodle> Noodles { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}
