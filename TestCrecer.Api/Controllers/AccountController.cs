using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestCrecer.Application.Interfaces.UserAccount;
using TestCrecer.Core.Dtos;
using TestCrecer.Core.Entities;

namespace TestCrecer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IAccountService _service;

        public AccountController(IMapper mapper, IAccountService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet("accounts/{accId:int}")]
        public async Task<IActionResult> GetById(int accId)
        {
            var response = await _service.Single(x => x.Id == accId).ConfigureAwait(false);

            return Ok(_mapper.Map<AccountDto>(response));
        }

        [HttpGet("accounts")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAll().ConfigureAwait(false);

            return Ok(_mapper.Map<IEnumerable<AccountDto>>(response));
        }

        [HttpPost]
        public async Task<IActionResult> Post(AccountDto acc)
        {
            var dataToSave = _mapper.Map<Account>(acc);

            var result = await _service.Create(dataToSave).ConfigureAwait(false);

            if (result > 0) return Ok();

            return BadRequest();
        }

        [HttpDelete("{accId:int}")]
        public async Task<IActionResult> Delete(int accId)
        {
            var dataToRemove = await _service.Single(x => x.Id == accId).ConfigureAwait(false);

            await _service.Remove(dataToRemove).ConfigureAwait(false);

            return Ok();
        }

        [HttpPut("{accId:int}")]
        public async Task<IActionResult> Update(int accId, AccountDto data)
        {
            var dataToUpdate = await _service.Single(x => x.Id == accId).ConfigureAwait(false);
            dataToUpdate.EmployeeSalary = data.EmployeeSalary;
            dataToUpdate.Company = data.Company;
            dataToUpdate.Interest = data.Interest;
            dataToUpdate.UserId = data.UserId;

            var result = await _service.Update(dataToUpdate).ConfigureAwait(false);

            if (result > 0) return Ok();

            return BadRequest();
        }

    }
}