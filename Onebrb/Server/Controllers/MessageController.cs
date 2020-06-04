using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Onebrb.Server.Data;
using Onebrb.Server.Models;
using Onebrb.Shared.ViewModels.Message;

namespace Onebrb.Server.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public MessageController(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Gets individual message by id (from route id)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Message</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessageById(Guid id)
        {
            var result =  await _db.Messages.FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        /// <summary>
        /// Creates a new message
        /// </summary>
        /// <param name="model">CreateMessageViewModel</param>
        /// <returns>Message</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostMessage([FromBody] CreateMessageViewModel model)
        {
            var guid = Guid.NewGuid();

            // Automapper tomorrow
            var message = new Message
            {
                Id = guid,
                AuthorId = model.Author,
                Body = model.Body,
                DateSent = DateTime.UtcNow,
                RecipientId = model.Recipient,
                Title = model.Title
            };

            await _db.Messages.AddAsync(message);
            await _db.SaveChangesAsync();

            var msgFromDb = _db.Messages.FirstOrDefaultAsync(x => x.Id == guid);

            return CreatedAtAction(nameof(GetMessageById), new { id = guid }, model);
        }
    }
}
