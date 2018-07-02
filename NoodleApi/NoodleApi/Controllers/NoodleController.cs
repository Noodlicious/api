﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NoodleApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NoodleApi.Controllers
{
    [Route("api/noodle")]
    public class NoodleController : Controller
    {
        private readonly NoodleContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public NoodleController(NoodleContext context)
        {
            _context = context;

            if (_context.Noodles.Count() == 0)
            {
                _context.Noodles.Add(new Noodle
                {
                    Name = "Chapagetti",
                    Brand = "Nongshim",
                    ImgUrl = "https://i5.walmartimages.com/asr/ca45cf0b-f851-4d3e-a302-e36af6298a33_1.be1e986a037214b0cd5d2f7f96def4e7.jpeg",
                    Country = "South Korea",
                    Flavor = "Chajang"
                });

                _context.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<Noodle>> GetAll()
        {
            return _context.Noodles.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetNoodle")]
        public async Task<ActionResult<Noodle>> GetById(long id)
        {
            var noodle = await _context.Noodles.FindAsync(id);
            if (noodle == null) return NotFound();
            return noodle;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="noodle"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Noodle noodle)
        {
            await _context.Noodles.AddAsync(noodle);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetNoodle", new { id = noodle.Id }, noodle);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="noodle"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody]Noodle noodle)
        {
            var dbNoodle = await _context.Noodles.FindAsync(id);
            if (dbNoodle == null) return NotFound();

            dbNoodle.Brand = noodle.Brand;
            dbNoodle.Country = noodle.Country;
            dbNoodle.Flavor = noodle.Flavor;
            dbNoodle.ImgUrl = noodle.ImgUrl;
            dbNoodle.Name = noodle.Name;

            _context.Noodles.Update(dbNoodle);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var noodle = await _context.Noodles.FindAsync(id);
            if (noodle == null) return NotFound();

            _context.Noodles.Remove(noodle);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
