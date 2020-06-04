using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Onebrb.Server.Data;
using Onebrb.Shared.ViewModels.User;

namespace Onebrb.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public UserController(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        /// <summary>
        /// Checks if a given username exists asynchronously
        /// </summary>
        /// <param name="username">The username to check against</param>
        /// <returns>true or false</returns>
        [HttpGet("{username}")]
        public async Task<IActionResult> GetUserByUsernameAsync(string username)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.UserName == username);

            if (user == null)
            {
                return NotFound(user);
            }
            else
            {
                var viewModel = _mapper.Map<UserViewModel>(user);
                return Ok(viewModel);
            }
        }
    }
}
