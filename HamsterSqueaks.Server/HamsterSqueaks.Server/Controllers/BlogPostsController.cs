using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HamsterSqueaks.Server.Data;
using HamsterSqueaks.Server.Models;

namespace HamsterSqueaks.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/BlogPosts")]
    public class BlogPostsController : Controller
    {
        private readonly HamsterSqueaksDbContext _context;

        public BlogPostsController(HamsterSqueaksDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetBlogPosts()
        {
            var blogPosts = await _context.BlogPosts.ToListAsync();
            return Ok(blogPosts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogPost([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var blogPost = await _context.BlogPosts.SingleOrDefaultAsync(m => m.Id == id);

            if (blogPost == null)
            {
                return NotFound();
            }

            return Ok(blogPost);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlogPost([FromRoute] int id, [FromBody] BlogPost blogPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != blogPost.Id)
            {
                return BadRequest();
            }

            _context.Entry(blogPost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogPostExists(id))
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

        [HttpPost]
        public async Task<IActionResult> PostBlogPost([FromBody] BlogPost blogPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.BlogPosts.Add(blogPost);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlogPost", new { id = blogPost.Id }, blogPost);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogPost([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var blogPost = await _context.BlogPosts.SingleOrDefaultAsync(m => m.Id == id);
            if (blogPost == null)
            {
                return NotFound();
            }

            _context.BlogPosts.Remove(blogPost);
            await _context.SaveChangesAsync();

            return Ok(blogPost);
        }

        private bool BlogPostExists(int id)
        {
            return _context.BlogPosts.Any(e => e.Id == id);
        }
    }
}