using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Onebrb.Server.Data;
using Onebrb.Server.Models;

namespace Onebrb.Server.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
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

        [HttpPost]
        public async Task<bool> SendMessageAsync(string message)
        {
            var messageModel = new Message
            {
                AuthorId = "1",
                Body = message,
                DateSent = DateTime.UtcNow,
                RecipientId = "2",
                Title = "Hi"
            };

            await _db.Messages.AddAsync(messageModel);
            await _db.SaveChangesAsync();

            return true;
        }
    }
}
