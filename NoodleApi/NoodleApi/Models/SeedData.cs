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
        /// <summary>
        /// Adds default noodle information to the database if it is empty.
        /// </summary>
        /// <param name="serviceProvider">The service used (for dependency injection).</param>
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new NoodleContext(
                    serviceProvider.GetRequiredService<DbContextOptions<NoodleContext>>()))
            {
                if (context.Noodles.Any()) return;

                context.Brands.AddRange(
                new Brand
                {
                    Name = "Nongshim",
                    Country = "South Korea"
                },

                new Brand
                {
                    Name = "Ottogi",
                    Country = "South Korea"
                },

                new Brand
                {
                    Name = "Mama",
                    Country = "Thailand"
                },

                new Brand
                {
                    Name = "Nissin",
                    Country = "Japan"
                });

                context.SaveChanges();

                context.Noodles.AddRange(
                    new Noodle
                    {
                        Name = "Chapagetti",
                        BrandId = GetID("Nongshim", context),
                        ImgUrl = "https://i5.walmartimages.com/asr/ca45cf0b-f851-4d3e-a302-e36af6298a33_1.be1e986a037214b0cd5d2f7f96def4e7.jpeg",
                        Flavor = "Chajang",
                        Description = "Chapagetti is Nongshim’s version of the Chajangmyun Noodles, an immensly popular noodle dish in Korea. Nongshim spent years developing and tweaking the secret Chajang recipe until it tasted just like the common Chajangmyun shops found all over Korea. Making Chajangmyun is a very difficult process that few outside the business are able to do, but Nongshim Chapagetti makes it easy for you to enjoy the taste of Chajangmyun in your own home!"
                    },

                    new Noodle
                    {
                        Name = "Shin Black",
                        BrandId = GetID("Nongshim", context),
                        ImgUrl = "http://blogs.ubc.ca/ksw4268/files/2013/01/nongshim_shin_black_400_6_21.jpg",
                        Flavor = "Beef (Spicy)",
                        Description = "In 1986 Shin Ramyun first made its debut, and quickly rose to become the most popular ramyun in Korea. Year after year and decade after decade, Shin Ramyun’s unique spicy flavor ensured its place on top in the hearts of Korea’s ramyun lovers. 25 years later Nongshim released Shin Ramyun Black to commemorate 25 years since the inception of Shin Ramyun. Developing the product had taken three years of listening to customer input and researching foods to address consumers’ wants and needs in taste, convenience, and nutrition."
                    },

                    new Noodle
                    {
                        Name = "Jin Ramen (Hot)",
                        BrandId = GetID("Ottogi", context),
                        ImgUrl = "http://i.ebayimg.com/images/i/222167520841-0-1/s-l1000.jpg",
                        Flavor = "Beef (Spicy)",
                        Description = "Easy to prepare. Hot ramen from the famous Otago., Asian style noodle., Prepare in 5 min., No msg. 4.23-ounce packages (pack of 20). World famous Otago jinn hot ramen."
                    },

                    new Noodle
                    {
                        Name = "Pho Ga",
                        BrandId = GetID("Mama", context),
                        ImgUrl = "https://www.arts2chine.fr/5658-thickbox_default/soupe-vermicelles-de-riz-mama-pho-ga-poulet-55g.jpg",
                        Flavor = "Chicken",
                        Description = "Pho Ga Rice Noodles with Artificial Chicken Flavor is a quick and easy meal solution whenever you're hungry or craving some Pho. The authentic chicken flavored broth, mixed with a hint of basil and lime, creates an aromatic and savory broth that's perfect for a cold day. With its unique flavor profile unlike any other noodles you've tried, Pho Ga Instant Noodles is the perfect way to try them out. With a simple linguine-shaped rice noodle and its flavorful soup mix, it's as simple as adding water to prepare your meal. With only 240 calories and 0 grams of trans-fat per packet, this is a great choice when you're in need of a quick and easy meal at home."
                    },

                    new Noodle
                    {
                        Name = "Top Ramen (Oriental)",
                        BrandId = GetID("Nissin", context),
                        ImgUrl = "https://img.grouponcdn.com/stores/59trEtUmLcseiwanhKv63d/storesoi1327055-1000x600/v1/c700x420.jpg",
                        Flavor = "Oriental",
                        Description = "Oodles of Noodles. 0 g Trans fat. Cooks in 3 minutes. Nissin Top Ramen is America's Original Ramen Noodle Soup and a family favorite since 1970. Top Ramen, for the very best in Ramen Noodle Soup."
                    });

                context.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static int GetID(string name, NoodleContext context)
        {
            return (from brand in context.Brands
                    where brand.Name == name
                    select brand.Id).ToArray()[0];
        }
    }
}
