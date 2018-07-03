using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NoodleApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NoodleApi.Controllers
{
    [Route("api/brand")]
    public class BrandController : Controller
    {
        private readonly NoodleContext _context;

        public BrandController(NoodleContext context)
        {
            _context = context;
        }

        //get all
        [HttpGet]
        public ActionResult<List<Brand>> GetAll()
        {
            return _context.Brands.ToList();
        }

        //get one
        [HttpGet("{id}", Name = "GetBrand")]
        public async Task<ActionResult<Brand>> GetByID(long id)
        {
            Brand brand = await _context.Brands.FindAsync(id);
            if (brand == null) return NotFound();
            else return brand;
        }

        //post
        [HttpPost()]
        public async Task<IActionResult> Create([FromBody]Brand brand)
        {
            if (BrandExists(brand.Name)) return BadRequest();

            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetBrand", new { id = brand.Id }, brand);
        }

        //update
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody]Brand brand)
        {
            Brand dbBrand = await _context.Brands.FindAsync(id);
            if (dbBrand == null) return NotFound();

            if (brand.Country != null) dbBrand.Country = brand.Country;
            if (brand.Name != null)
            {
                if (BrandExists(brand.Name)) return BadRequest();
                else dbBrand.Name = brand.Name;
            }

            _context.Brands.Update(dbBrand);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            Brand brand = _context.Brands.Find(id);
            if (brand == null) return NotFound();

            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        public bool BrandExists(string name)
        {
            List<string> names = (from brand in _context.Brands
                                  select brand.Name).ToList();
            return names.Contains(name);
        }
    }
}
