using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace NoodleApi.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new NoodleContext(
                    serviceProvider.GetRequiredService<DbContextOptions<NoodleContext>>()))
            {
                if (context.Noodles.Any()) return;

                context.Noodles.AddRange(
                    new Noodle
                    {
                        Name = "Chapagetti",
                        Brand = "Nongshim",
                        ImgUrl = "https://i5.walmartimages.com/asr/ca45cf0b-f851-4d3e-a302-e36af6298a33_1.be1e986a037214b0cd5d2f7f96def4e7.jpeg",
                        Country = "South Korea",
                        Flavor = "Chajang"
                    },

                    new Noodle
                    {
                        Name = "Shin Black",
                        Brand = "Nongshim",
                        ImgUrl = "http://blogs.ubc.ca/ksw4268/files/2013/01/nongshim_shin_black_400_6_21.jpg",
                        Country = "South Korea",
                        Flavor = "Beef (Spicy)"
                    },

                    new Noodle
                    {
                        Name = "Jin Ramen (Hot)",
                        Brand = "Ottogi",
                        ImgUrl = "http://i.ebayimg.com/images/i/222167520841-0-1/s-l1000.jpg",
                        Country = "South Korea",
                        Flavor = "Beef (Spicy)"
                    },

                    new Noodle
                    {
                        Name = "Pho Ga",
                        Brand = "Mama",
                        ImgUrl = "https://www.arts2chine.fr/5658-thickbox_default/soupe-vermicelles-de-riz-mama-pho-ga-poulet-55g.jpg",
                        Country = "Thailand",
                        Flavor = "Chicken"
                    },

                    new Noodle
                    {
                        Name = "Top Ramen (Oriental)",
                        Brand = "Nissin",
                        ImgUrl = "https://img.grouponcdn.com/stores/59trEtUmLcseiwanhKv63d/storesoi1327055-1000x600/v1/c700x420.jpg",
                        Country = "Japan",
                        Flavor = "Oriental"
                    });
                context.SaveChanges();
            }
        }
    }
}
