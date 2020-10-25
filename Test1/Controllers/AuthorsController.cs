using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        BookShopContext db;
        public AuthorsController(BookShopContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> Get()
        {
            return await db.Authors.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> Get(int id)
        {
            Author author  = await db.Authors.FirstOrDefaultAsync(x => x.Id == id);
            if (author == null)
                return NotFound();
            return new ObjectResult(author);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Author>> Post(Author author)
        {
            if (author == null)
            {
                return BadRequest();
            }
            db.Authors.Add(author);
            await db.SaveChangesAsync();
            return Ok(author);
        }

        [HttpPut]
        public async Task<ActionResult<Author>> Put(Author author)
        {
            if (author == null)
            {
                return BadRequest();
            }
            if (!db.Authors.Any(x => x.Id == author.Id))
            {
                return NotFound();
            }

            db.Update(author);
            await db.SaveChangesAsync();
            return Ok(author);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Author>> Delete(int id)
        {
            Author author = db.Authors.FirstOrDefault(x => x.Id == id);
            if (author == null)
            {
                return NotFound();
            }
            db.Authors.Remove(author);
            await db.SaveChangesAsync();
            return Ok(author);
        }
    }
}
