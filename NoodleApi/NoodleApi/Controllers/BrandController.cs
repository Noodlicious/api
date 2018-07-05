using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NoodleApi.Models;

namespace NoodleApi.Controllers
{
    [Route("api/brand")]
    public class BrandController : Controller
    {
        private readonly NoodleContext _context;

        /// <summary>
        /// Creates an instance of the BrandController class
        /// </summary>
        /// <param name="context">The Brand database context</param>
        public BrandController(NoodleContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all brands
        /// The test for this is called CanGetAllBrands
        /// </summary>
        /// <returns>List of Brands</returns>
        [HttpGet]
        public ActionResult<List<Brand>> GetAll()
        {
            return _context.Brands.ToList();
        }

        /// <summary>
        /// Gets a brand by id
        /// Test for this is called CanGetBrandById
        /// </summary>
        /// <param name="id"></param>
        /// <returns>the requested brand object</returns>
        [HttpGet("{id}", Name = "GetBrand")]
        public async Task<ActionResult<Brand>> GetByID(int id)
        {
            Brand brand = await _context.Brands.FindAsync(id);
            //if there are no brands, return a NotFound message
            if (brand == null) return NotFound();
            else return brand;
        }

        /// <summary>
        /// Add a new brand
        /// Test for this is called CanCreateNewBrand()
        /// </summary>
        /// <param name="brand"></param>
        /// <returns>CreatedAtRoute returns a 201 for a a POST that creates a new resoure on the server</returns>
        [HttpPost()]
        public async Task<IActionResult> Create([FromBody]Brand brand)
        {   //BrandExists is a helper method.  Look at the very bottom for more details
            if (BrandExists(brand.Name)) return BadRequest();

            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetBrand", new { id = brand.Id }, brand);
        }

        /// <summary>
        /// Updates a brand by Id
        /// Test for this is called CanUpdateBrand()
        /// </summary>
        /// <param name="id"></param>
        /// <param name="brand"></param>
        /// <returns>204 response b/c the content can be identified by a URI</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]Brand brand)
        {
            Brand dbBrand = await _context.Brands.FindAsync(id);
            if (dbBrand == null) return NotFound();
            //if the country is not null, set that country to its reference, dbCountry
            if (brand.Country != null) dbBrand.Country = brand.Country;
            if (brand.Name != null)
            {   //BrandExists is a helper method.  Look at the very bottom for more details
                if (BrandExists(brand.Name)) return BadRequest();
                //if the brand exists, update its name
                else dbBrand.Name = brand.Name;
            }

            _context.Brands.Update(dbBrand);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Deletes a brand by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>204 response b/c the content can be identified by a URI</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Brand brand = _context.Brands.Find(id);
            if (brand == null) return NotFound();

            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// ApiExplorerSettings is implemented so that Swagger ignores this method
        /// b/c this is not a valid HTTP request.  This is a helper method to
        /// check if a brand exists.  This method is used in the Update and Create
        /// methods
        /// </summary>
        /// <param name="name"></param>
        /// <returns>true if the brand exists, and false if it doesn't exist</returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        public bool BrandExists(string name)
        {   //stores all the names of the brand, that exists in the database, into a list 
            List<string> names = (from brand in _context.Brands
                                  select brand.Name).ToList();
            return names.Contains(name);
        }
    }
}
