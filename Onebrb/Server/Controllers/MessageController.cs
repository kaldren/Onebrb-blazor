﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public MessageController(ApplicationDbContext db, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _mapper = mapper;
            _userManager = userManager;
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
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            var recipient = await _db.Users.FirstOrDefaultAsync(x => x.UserName == model.Recipient);

            if (recipient == null)
            {
                return BadRequest(new { Message = $"Recipient {model.Recipient} not found." });
            }
            model.RecipientId = recipient.Id;
            model.AuthorId = currentUser.Id;

            var id = Guid.NewGuid();

            var message = _mapper.Map<Message>(model);

            await _db.Messages.AddAsync(message);
            await _db.SaveChangesAsync();

            var msgFromDb = await _db.Messages.FirstOrDefaultAsync(x => x.Id == id);

            return CreatedAtAction(nameof(GetMessageById), new { id }, model);
        }
    }
}
