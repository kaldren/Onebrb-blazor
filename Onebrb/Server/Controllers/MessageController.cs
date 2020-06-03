using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Onebrb.Server.Data;
using Onebrb.Server.Models;

namespace Onebrb.Server.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]/[action]")]
    public class MessageController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MessageController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<Message> GetMessageById(Guid id)
        {
            return await _db.Messages.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync(string message)
        {
            var guid = Guid.NewGuid();

            var messageModel = new Message
            {
                Id = guid,
                AuthorId = "1",
                Body = message,
                DateSent = DateTime.UtcNow,
                RecipientId = "2",
                Title = "Hi"
            };

            await _db.Messages.AddAsync(messageModel);
            await _db.SaveChangesAsync();

            var msgFromDb = _db.Messages.FirstOrDefaultAsync(x => x.Id == guid);

            return CreatedAtAction(nameof(GetMessageById), new { id = guid });
        }
    }
}
