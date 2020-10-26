using System;
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
    public class BooksController : ControllerBase
    {
        BookShopContext db;
        public BooksController(BookShopContext context)
        {
            db = context;
            if (!db.Books.Any())
            {
                db.Books.Add(new Book
                {
                    Name = "Book1",
                    Author = db.Authors.FirstOrDefault(),
                    CoverType = db.CoverTypes.FirstOrDefault(),
                    Genre = db.Genres.FirstOrDefault(),
                    AgeCategory = db.AgeCategories.FirstOrDefault(p => p.Min >= 7),
                    Year = 1818,
                });
                db.SaveChanges();
                db.Books.Add(new Book
                {
                    Name = "Book2",
                    Author = db.Authors.FirstOrDefault(),
                    CoverType = db.CoverTypes.FirstOrDefault(),
                    Genre = db.Genres.FirstOrDefault(),
                    AgeCategory = db.AgeCategories.FirstOrDefault(p => p.Min >= 7),
                    Year = 1818,
                });
                db.SaveChanges();
                db.Books.Add(new Book
                {
                    Name = "Book3",
                    Author = db.Authors.FirstOrDefault(),
                    CoverType = db.CoverTypes.FirstOrDefault(),
                    Genre = db.Genres.FirstOrDefault(),
                    AgeCategory = db.AgeCategories.FirstOrDefault(p => p.Min >= 17),
                    Year = 1818,
                });
                db.SaveChanges();
                db.Books.Add(new Book
                {
                    Name = "Book10",
                    Author = db.Authors.FirstOrDefault(p => p.Id == 2),
                    CoverType = db.CoverTypes.FirstOrDefault(p => p.Id == 2),
                    Genre = db.Genres.FirstOrDefault(p => p.Id == 2),
                    AgeCategory = db.AgeCategories.FirstOrDefault(p => p.Min >= 17),
                });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> Get()
        {
            return await db.Books.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            Book book = await db.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (book == null)
                return NotFound();
            return new ObjectResult(book);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> Post(Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            db.Books.Add(book);
            await db.SaveChangesAsync();
            return Ok(book);
        }

        [HttpPost("Name")]
        public async Task<ActionResult<IEnumerable<Book>>> Post([FromBody] string name)
        {
            return await db.Books.Where(p => p.Name.Contains(name)).ToListAsync();
        }
        [HttpPost("Author")]
        public async Task<ActionResult<IEnumerable<Book>>> Post([FromBody] Author author)
        {
            return await db.Books.Where(p => p.Author.Id == author.Id).ToListAsync();
        }

        [HttpPost("CoverType")]
        public async Task<ActionResult<IEnumerable<Book>>> Post([FromBody] CoverType coverType)
        {
            return await db.Books.Where(p => p.CoverType.Id == coverType.Id).ToListAsync();
        }
        [HttpPost("Genre")]
        public async Task<ActionResult<IEnumerable<Book>>> Post([FromBody] Genre genre)
        {
            return await db.Books.Where(p => p.Genre.Id == genre.Id)
                .ToListAsync();
        }

        [HttpPost("AgeCategory")]
        public async Task<ActionResult<IEnumerable<Book>>> Post([FromBody] AgeCategory ageCategory)
        {
            return await db.Books.Where(p => p.AgeCategory.Id == ageCategory.Id).ToListAsync();
        }

        [HttpPut]
        public async Task<ActionResult<Book>> Put(Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            if (!db.Books.Any(x => x.Id == book.Id))
            {
                return NotFound();
            }

            db.Update(book);
            await db.SaveChangesAsync();
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> Delete(int id)
        {
            Book book = db.Books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            db.Books.Remove(book);
            await db.SaveChangesAsync();
            return Ok(book);
        }
    }
}
