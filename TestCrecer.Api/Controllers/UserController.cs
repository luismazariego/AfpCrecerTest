using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TestCrecer.Application.Interfaces.UserAccount;
using TestCrecer.Core.Dtos;
using System.Threading.Tasks;
using System.Collections.Generic;
using TestCrecer.Core.Entities;

namespace TestCrecer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _service;

        public UserController(IMapper mapper, IUserService service )
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet("users/{userId:int}")]
        public async Task<IActionResult> GetById(int userId)
        {
            var response = await _service.Single(x => x.Id == userId).ConfigureAwait(false);
            
            return Ok(_mapper.Map<UserDto>(response));
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAll().ConfigureAwait(false);

            return Ok(_mapper.Map<IEnumerable<UserDto>>(response));
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserDto user)
        {
            var dataToSave = _mapper.Map<User>(user);

            var result = await _service.Create(dataToSave).ConfigureAwait(false);

            if (result > 0) return Ok();

            return BadRequest();
        }

        [HttpDelete("{userId:int}")]
        public async Task<IActionResult> Delete(int userId)
        {
            var dataToRemove = await _service.Single(x => x.Id == userId).ConfigureAwait(false);

            await _service.Remove(dataToRemove).ConfigureAwait(false);

            return Ok();
        }

        [HttpPut("{userId:int}")]
        public async Task<IActionResult> Update(int userId, UserDto data)
        {
            var dataToUpdate = await _service.Single(x => x.Id == userId).ConfigureAwait(false);

            dataToUpdate.Email = data.Email;
            dataToUpdate.Firstname = data.Firstname;
            dataToUpdate.Lastname = data.Lastname;
            dataToUpdate.Phone = data.Phone;

            var result = await _service.Update(dataToUpdate).ConfigureAwait(false);

            if (result > 0) return Ok();

            return BadRequest();
        }

    }
}