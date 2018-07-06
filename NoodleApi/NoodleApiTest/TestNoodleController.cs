using NoodleApi.Models;
using NoodleApi.Controllers;
using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace NoodleApiTest
{
    public class TestNoodleController
    {
        [Fact]
        public async void CanGetNoodleByID()
        {
            DbContextOptions<NoodleContext> options =
                new DbContextOptionsBuilder<NoodleContext>()
                .UseInMemoryDatabase("CanGetNoodlesByID")
                .Options;

            using (NoodleContext context = new NoodleContext(options))
            {
                //arrange
                Noodle noodle1 = new Noodle();
                noodle1.Id = 1;
                noodle1.Name = "Organic Ramen";
                Noodle noodle2 = new Noodle();
                noodle2.Id = 2;
                noodle2.Name = "Shoyu Ramen";
                Noodle noodle3 = new Noodle();
                noodle3.Id = 3;
                noodle3.Name = "Bestest Ramen";

                //act
                await context.Noodles.AddAsync(noodle1);
                await context.Noodles.AddAsync(noodle2);
                await context.Noodles.AddAsync(noodle3);

                await context.SaveChangesAsync();

                NoodleController nc = new NoodleController(context);
                var findNoodle = nc.GetById(1);

                //assert
                Assert.Equal(noodle1.Name, findNoodle.Result.Value.Name);
            }
        }

        [Fact]
        public async void CanGetAllNoodle()
        {
            DbContextOptions<NoodleContext> options =
                new DbContextOptionsBuilder<NoodleContext>()
                .UseInMemoryDatabase("CanGetAllNoodles")
                .Options;

            using (NoodleContext context = new NoodleContext(options))
            {
                //arrange
                Noodle noodle1 = new Noodle();
                noodle1.Id = 1;
                noodle1.Name = "Organic Ramen";
                Noodle noodle2 = new Noodle();
                noodle2.Id = 2;
                noodle2.Name = "Shoyu Ramen";
                Noodle noodle3 = new Noodle();
                noodle3.Id = 3;
                noodle3.Name = "Bestest Ramen";

                //act
                await context.Noodles.AddAsync(noodle1);
                await context.Noodles.AddAsync(noodle2);
                await context.Noodles.AddAsync(noodle3);
                await context.SaveChangesAsync();

                //assert
                Assert.Equal(3, context.Noodles.Count());
            }
        }

        [Fact]
        public async void CanDeleteNoodleByID()
        {
            DbContextOptions<NoodleContext> options =
                new DbContextOptionsBuilder<NoodleContext>()
                .UseInMemoryDatabase("CanDeleteNoodlesByID")
                .Options;

            using (NoodleContext context = new NoodleContext(options))
            {
                //arrange
                Noodle noodle1 = new Noodle();
                noodle1.Id = 1;
                noodle1.Name = "Organic Ramen";
                Noodle noodle2 = new Noodle();
                noodle2.Id = 2;
                noodle2.Name = "Shoyu Ramen";
                Noodle noodle3 = new Noodle();
                noodle3.Id = 3;
                noodle3.Name = "Bestest Ramen";

                //act
                await context.Noodles.AddAsync(noodle1);
                await context.Noodles.AddAsync(noodle2);
                await context.Noodles.AddAsync(noodle3);
                await context.SaveChangesAsync();

                var findNoodle = context.Noodles.Find(1);

                NoodleController nc = new NoodleController(context);

                var deletedNoodle = nc.Delete(findNoodle.Id);

                //assert
                Assert.Equal(2, context.Noodles.Count());
            }
        }

        [Fact]
        public async void CanUpdateNoodle()
        {
            DbContextOptions<NoodleContext> options = new DbContextOptionsBuilder<NoodleContext>()
                .UseInMemoryDatabase("CanUpdateNoodle").Options;

            using (NoodleContext context = new NoodleContext(options))
            {
                //arrange
                Noodle noodle = new Noodle
                {
                    Flavor = "Tom Yum"
                };

                NoodleController nc = new NoodleController(context);

                //act
                await context.Noodles.AddAsync(noodle);
                await context.SaveChangesAsync();
                //the seeded data at id# 1 is Chapagetti, and this
                //test will override the flavor
                var updatedNoodle = nc.Update(1, noodle);

                //assert
                Assert.Equal("Tom Yum", noodle.Flavor);
            }
        }

        [Fact]
        public async void CanCreateNewNoodle()
        {
            DbContextOptions<NoodleContext> options = new DbContextOptionsBuilder<NoodleContext>()
                .UseInMemoryDatabase("CanPostNewNoodle")
                .Options;

            using (NoodleContext context = new NoodleContext(options))
            {
                //arrange
                Noodle noodle = new Noodle
                {
                    Name = "Instant Noodle Shrimp",
                    BrandId = 2,
                    Flavor = "Tom Yum",
                    ImgUrl = "https://www.bing.com",
                    Description = "much tasty"
                };

                //act
                await context.Noodles.AddAsync(noodle);
                await context.SaveChangesAsync();

                NoodleController nc = new NoodleController(context);
                var addedNoodle = nc.Create(noodle);

                var results = context.Noodles.Where(x => x.Name == "Instant Noodle Shrimp");

                //assert
                Assert.Equal(1, results.Count());
            }
        }
    }
}