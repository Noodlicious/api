using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NoodleApi.Models;

namespace NoodleApi.Controllers
{
    [Route("api/noodle")]
    public class NoodleController : Controller
    {
        private readonly NoodleContext _context;

        /// <summary>
        /// Creates a new instance of the NoodleController class.
        /// </summary>
        /// <param name="context">The Noodle database context.</param>
        public NoodleController(NoodleContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets a list of all noodles in the database.
        /// Test for this is called CanGetAllNoodle()
        /// </summary>
        /// <returns>A list of noodles.</returns>
        [HttpGet]
        public ActionResult<List<Noodle>> GetAll()
        {
            return _context.Noodles.ToList();
        }

        /// <summary>
        /// Gets a noodle by its ID.
        /// Test for this is called CanGetNoodleByID()
        /// </summary>
        /// <param name="id">The noodle's ID</param>
        /// <returns>A noodle with a matching ID.</returns>
        [HttpGet("{id}", Name = "GetNoodle")]
        public async Task<ActionResult<Noodle>> GetById(int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var noodle = await _context.Noodles.FindAsync(id);
            if (noodle == null) return NotFound();
            return noodle;
        }

        /// <summary>
        /// Adds a noodle to the database.
        /// Test for this is called CanCreateNewNoodle()
        /// </summary>
        /// <param name="noodle">The noodle being added.</param>
        /// <returns>A 201 response.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Noodle noodle)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _context.Noodles.AddAsync(noodle);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetNoodle", new { id = noodle.Id }, noodle);
        }

        /// <summary>
        /// Updates a noodle's information.
        /// Test for this is called CanUpdateNoodle()
        /// </summary>
        /// <param name="id">The ID of the noodle being updated.</param>
        /// <param name="noodle">A noodle object with updated information.</param>
        /// <returns>A 204 response (if the ID is found).</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]Noodle noodle)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var dbNoodle = await _context.Noodles.FindAsync(id);
            if (dbNoodle == null) return NotFound();

            //if (noodle.BrandId != null) dbNoodle.BrandId = noodle.BrandId;
            if (noodle.Flavor != null) dbNoodle.Flavor = noodle.Flavor;
            if (noodle.ImgUrl != null) dbNoodle.ImgUrl = noodle.ImgUrl;
            if (noodle.Name != null) dbNoodle.Name = noodle.Name;
            if (noodle.Description != null) dbNoodle.Description = noodle.Description;

            _context.Noodles.Update(dbNoodle);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Removes a noodle from the database.
        /// Test for this is called CanDeleteNoodleByID()
        /// </summary>
        /// <param name="id">The ID of the noodle to be removed.</param>
        /// <returns>A 204 response (if the ID is found).</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var noodle = await _context.Noodles.FindAsync(id);
            if (noodle == null) return NotFound();

            _context.Noodles.Remove(noodle);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
