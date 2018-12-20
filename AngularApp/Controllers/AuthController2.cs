using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AngularApp.Data;
using AngularApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;

namespace AngularApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class Products2Controller : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public Products2Controller(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Account> GetAccounts()
        {
            return _repo.GetAccounts();
        }

        [HttpGet("{id}")]
        public async Task<Account> GetProduct(int id)
        {
            return await _repo.GetAccount(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool saved = await _repo.Save();
            if (saved)
            {
                return NoContent();
            }
            return BadRequest("Error saving changes");
        }

        [HttpPut("altupdate/{id}")]
        public async Task<IActionResult> AlternateUpdateAccount(int id, AccountUpdateDTO account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentProduct = await _repo.GetAccount(id);
            _mapper.Map(account. currentAccount);
            bool saved = await _repo.Save();
            if (saved)
            {
                return NoContent();
            }
            return BadRequest("Error saving changes");
        }
    }
}