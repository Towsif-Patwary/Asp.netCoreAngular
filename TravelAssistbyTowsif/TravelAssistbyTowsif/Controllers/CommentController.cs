using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAssistbyTowsif.Entity.Models;

namespace TravelAssistbyTowsif.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly AuthenticationContext _context;

        public CommentController(AuthenticationContext context)
        {
            _context = context;
        }

        // GET: api/Comment/GetComments
        [HttpGet]
        [Route("GetComments")]
        public async Task<ActionResult<IEnumerable<CommentModel>>> GetComments()
        {
            return await _context.Comments.ToListAsync();
        }

        // POST: api/Comment/PostCommentModel
        [HttpPost]
        [Route("PostCommentModel")]
        public async Task<ActionResult<CommentModel>> PostCommentModel(CommentModel commentModel)
        {
            _context.Comments.Add(commentModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommentModel", new { id = commentModel.CommentId }, commentModel);
        }

        // GET: api/Place/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentModel>> GetCommentModel(int id)
        {
            var commentModel = await _context.Comments.FindAsync(id);

            if (commentModel == null)
            {
                return NotFound();
            }

            return commentModel;
        }

        private bool CommentModelExists(int id)
        {
            return _context.Comments.Any(e => e.CommentId == id);
        }
    }
}
