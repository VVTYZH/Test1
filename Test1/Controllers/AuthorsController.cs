using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Data.Models;
using Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private IRepository<Author> ContextAuthors { get; set; }

        public AuthorsController(IRepository<Author> contextAuthors)
        {
            ContextAuthors = contextAuthors;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> Get()
        {
            return Ok(await ContextAuthors.AllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> Get(int id)
        {
            Author author = await ContextAuthors.FindByIdAsync(id);
            if (author == null)
                return NotFound();
            return new ObjectResult(author);
        }

        [HttpPost]
        public async Task<ActionResult<Author>> Post(Author author)
        {
            if (author == null)
            {
                return BadRequest();
            }
            await ContextAuthors.AddAsync(author);
            return Ok(author);
        }

        [HttpPut]
        public async Task<ActionResult<Author>> Put(Author author)
        {
            if (author == null || author?.Id is null)
            {
                return BadRequest();
            }
            if (!(await ContextAuthors.FindByIdAsync(author.Id) == null))
            {
                return NotFound();
            }

            await ContextAuthors.UpdateAsync(author);
            return Ok(author);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Author>> Delete(int id)
        {
            Author author = await ContextAuthors.FindByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            await ContextAuthors.DeleteAsync(author);
            return Ok(author);
        }
    }
}
