using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HealthPlusPlus_AW.Security2.Authorization.Attributes;
using HealthPlusPlus_AW.Security2.Domain.Models;
using HealthPlusPlus_AW.Security2.Domain.Repositories;
using HealthPlusPlus_AW.Security2.Domain.Services;
using HealthPlusPlus_AW.Security2.Domain.Services.Communication;
using HealthPlusPlus_AW.Security2.Resources;
using Microsoft.AspNetCore.Mvc;

namespace HealthPlusPlus_AW.Security2.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class UserSecController : ControllerBase
    {
        private readonly IUserSecService _userSecService;
        private readonly IMapper _mapper;

        public UserSecController(IUserSecService userSecService, IMapper mapper)
        {
            _userSecService = userSecService;
            _mapper = mapper;
        }
        
        [AllowAnonymous]
        [HttpPost("auth/sign-in")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest request)
        {
            var response = await _userSecService.Authenticate(request);
            return Ok(response);
        }
        
        [AllowAnonymous]
        [HttpPost("auth/sign-up")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            await _userSecService.RegisterAsync(request);
            return Ok(new { message = "Registration successful." });
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userSecService.GetByIdAsync(id);
            var resource = _mapper.Map<UserSec, UserSecResource>(user);
            return Ok(resource);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userSecService.ListAsync();
            var resources = _mapper.Map<IEnumerable<UserSec>, IEnumerable<UserSecResource>>(users);
            return Ok(resources);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateRequest request)
        {
            await _userSecService.UpdateAsync(id, request);
            return Ok(new { message = "User updated successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userSecService.DeleteAsync(id);
            return Ok(new { message = "User deleted successfully."});
        }
    }
}