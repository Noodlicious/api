using NoodleApi.Models;
using NoodleApi.Controllers;
using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SetupTests
{
    public class TestBrandControllerEndpoints
    {
        [Fact]
        public async void CanGetBrandById()
        {
            DbContextOptions<NoodleContext> options =
                new DbContextOptionsBuilder<NoodleContext>()
                .UseInMemoryDatabase("CanGetBrandById")
                .Options;

            using (NoodleContext context = new NoodleContext(options))
            {
                //arrange
                Brand brand1 = new Brand();
                brand1.Id = 1;
                brand1.Name = "Nissan";
                Brand brand2 = new Brand();
                brand2.Id = 2;
                brand2.Name = "Nongshim";
                Brand brand3 = new Brand();
                brand3.Id = 3;
                brand3.Name = "Mama";
                Brand brand4 = new Brand();
                brand4.Id = 4;
                brand4.Name = "Maggi";

                BrandController bc = new BrandController(context);

                //act
                await context.Brands.AddAsync(brand1);
                await context.Brands.AddAsync(brand2);
                await context.Brands.AddAsync(brand3);
                await context.Brands.AddAsync(brand4);
                await context.SaveChangesAsync();

                var findBrand = bc.GetByID(2);

                //assert
                Assert.Equal(brand2.Name, findBrand.Result.Value.Name);
            }
        }

        [Fact]
        public async void CanGetAllBrands()
        {
            DbContextOptions<NoodleContext> options =
                new DbContextOptionsBuilder<NoodleContext>()
                .UseInMemoryDatabase("CanGetAllBrands")
                .Options;

            using (NoodleContext context = new NoodleContext(options))
            {
                //arrange
                Brand brand1 = new Brand();
                brand1.Id = 1;
                Brand brand2 = new Brand();
                brand2.Id = 2;
                Brand brand3 = new Brand();
                brand3.Id = 3;
                Brand brand4 = new Brand();
                brand4.Id = 4;

                //act
                await context.Brands.AddAsync(brand1);
                await context.Brands.AddAsync(brand2);
                await context.Brands.AddAsync(brand3);
                await context.Brands.AddAsync(brand4);
                await context.SaveChangesAsync();

                //assert
                Assert.Equal(4, context.Brands.Count());
            }
        }

        [Fact]
        public async void CanCreateNewBrand()
        {
            DbContextOptions<NoodleContext> options =
                new DbContextOptionsBuilder<NoodleContext>()
                .UseInMemoryDatabase("CanCreateNewBrand")
                .Options;

            using (NoodleContext context = new NoodleContext(options))
            {
                //arrange
                Brand brand = new Brand
                {
                    Name = "Mi Goreng",
                    Country = "Indonesia"
                };
                BrandController bc = new BrandController(context);

                //act
                await context.AddAsync(brand);
                await context.SaveChangesAsync();

                var addedBrand = bc.Create(brand);

                var results = context.Brands.Where(x => x.Name == "Mi Goreng");

                //assert
                Assert.Equal(1, results.Count());
            }
        }

        [Fact]
        public async void CanUpdateBrand()
        {
            DbContextOptions<NoodleContext> options =
                new DbContextOptionsBuilder<NoodleContext>()
                .UseInMemoryDatabase("CanUpdateBrand")
                .Options;

            using (NoodleContext context = new NoodleContext(options))
            {
                //arrange
                Brand brand = new Brand
                {
                    Id = 1,
                    Name = "BestestBrand"
                };

                BrandController bc = new BrandController(context);

                //act
                await context.Brands.AddAsync(brand);
                await context.SaveChangesAsync();
                //the seeded data at id# 1 is Nongshim, and this 
                //test will change the brand name
                var updatedBrand = bc.Update(1, brand);

                //assert
                Assert.Equal("BestestBrand", brand.Name);
            }
        }

        [Fact]
        public async void CanDeleteBrandById()
        {
            DbContextOptions<NoodleContext> options =
                new DbContextOptionsBuilder<NoodleContext>()
                .UseInMemoryDatabase("CanDeleteBrandById")
                .Options;

            using (NoodleContext context = new NoodleContext(options))
            {
                //arrange
                Brand brand1 = new Brand();
                brand1.Id = 1;
                brand1.Name = "Number111";

                Brand brand2 = new Brand();
                brand2.Id = 2;
                brand2.Name = "Number222";

                Brand brand3 = new Brand();
                brand3.Id = 3;
                brand3.Name = "Number333";

                BrandController bc = new BrandController(context);

                //act
                await context.Brands.AddAsync(brand1);
                await context.Brands.AddAsync(brand2);
                await context.Brands.AddAsync(brand3);

                var findBrand = context.Brands.Find(1);
                var deletedBrand = bc.Delete(findBrand.Id);

                //assert
                Assert.Equal(2, context.Brands.Count());
            }
        }

        [Fact]
        public void CheckIfBrandExists()
        {
            DbContextOptions<NoodleContext> options =
                new DbContextOptionsBuilder<NoodleContext>()
                .UseInMemoryDatabase("CanCheckIfBrandExists")
                .Options;

            using (NoodleContext context = new NoodleContext(options))
            {
                //arrange
                Brand brand1 = new Brand();
                brand1.Name = "Nongshim";

                Brand brand2 = new Brand();
                brand2.Name = "Ottogi";

                Brand brand3 = new Brand();
                brand3.Name = "Samyang";

                BrandController bc = new BrandController(context);
                context.Brands.AddAsync(brand1);
                context.Brands.AddAsync(brand2);
                context.Brands.AddAsync(brand3);

                context.SaveChanges();

                //act
                var findBrand = bc.BrandExists("Nongshim");

                //assert
                Assert.True(findBrand);
            }
        }
    }
}
