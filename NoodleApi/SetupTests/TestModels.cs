using NoodleApi.Models;
using NoodleApi.Controllers;
using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SetupTests
{
    public class TestModels
    {
        [Fact]
        public void NoodleNameGetterTest()
        {
            Noodle noodle = new Noodle();
            noodle.Name = "Cheese Ramen";
            noodle.Flavor = "Cheese";

            noodle.Name = "Extra spicy ramen";

            Assert.Equal("Extra spicy ramen", noodle.Name);
        }

        [Fact]
        public void BrandNameGetterTest()
        {
            Brand brand = new Brand();
            brand.Name = "Maruchan";
            brand.Country = "Japan";

            brand.Name = "Nestle";

            Assert.Equal("Nestle", brand.Name);
        }
    }
}
