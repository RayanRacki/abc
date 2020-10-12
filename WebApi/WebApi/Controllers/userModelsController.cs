using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userModelsController : ControllerBase
    {
        private readonly userDbContext _context;

        public userModelsController(userDbContext context)
        {
            _context = context;
        }

        // GET: api/userModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<userModel>>> GetUser()
        {
            return await _context.User.ToListAsync();
        }

        // GET: api/userModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<userModel>> GetuserModel(int id)
        {
            var userModel = await _context.User.FindAsync(id);

            if (userModel == null)
            {
                return NotFound();
            }

            return userModel;
        }

        // PUT: api/userModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutuserModel(int id, userModel userModel)
        {
                userModel.Id = id;

                _context.Entry(userModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!userModelExists(id))
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

        // POST: api/userModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<userModel>> PostuserModel(userModel userModel)
        {
            _context.User.Add(userModel);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                SqlException innerException = e.InnerException as SqlException;
                //2601
                if (innerException.Number == 2601)
                {
                    return BadRequest("USER_ALREADY_EXISTS");
                }                
            }

            return CreatedAtAction("GetuserModel", new { id = userModel.Id }, userModel);
        }

        // DELETE: api/userModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<userModel>> DeleteuserModel(int id)
        {
            var userModel = await _context.User.FindAsync(id);
            if (userModel == null)
            {
                return NotFound();
            }

            _context.User.Remove(userModel);
            await _context.SaveChangesAsync();

            return userModel;
        }

        [Route("/api/userModels/auth")]
        [HttpPost]
        public async Task<IActionResult> AuthUser(loginModel loginModel)
        {
            var userModel = await _context.User.Include(user => user.addressModel).SingleOrDefaultAsync(e => e.email == loginModel.email);

            if (userModel == null)
            {
                return Content("BAD_LOGIN");
            }

            if (userModel.password != loginModel.password)
            {
                return Content("BAD_LOGIN");
            }

            return Ok(userModel);
        }

        private bool userModelExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
