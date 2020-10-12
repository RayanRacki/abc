using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class addressModelsController : ControllerBase
    {
        private readonly userDbContext _context;

        public addressModelsController(userDbContext context)
        {
            _context = context;
        }

        // GET: api/addressModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<addressModel>>> GetAddress()
        {
            return await _context.Address.ToListAsync();
        }

        // GET: api/addressModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<addressModel>> GetaddressModel(int id)
        {
            var addressModel = await _context.Address.FindAsync(id);

            if (addressModel == null)
            {
                return NotFound();
            }

            return addressModel;
        }

        // PUT: api/addressModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutaddressModel(int id, addressModel addressModel)
        {
            if (id != addressModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(addressModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!addressModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/addressModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<addressModel>> PostaddressModel(addressModel addressModel)
        {
            _context.Address.Add(addressModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetaddressModel", new { id = addressModel.Id }, addressModel);
        }

        // DELETE: api/addressModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<addressModel>> DeleteaddressModel(int id)
        {
            var addressModel = await _context.Address.FindAsync(id);
            if (addressModel == null)
            {
                return NotFound();
            }

            _context.Address.Remove(addressModel);
            await _context.SaveChangesAsync();

            return addressModel;
        }

        private bool addressModelExists(int id)
        {
            return _context.Address.Any(e => e.Id == id);
        }
    }
}
