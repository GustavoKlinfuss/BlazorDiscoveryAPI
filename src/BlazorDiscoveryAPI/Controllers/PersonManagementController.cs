using BlazorDiscoveryAPI.Application.Commands;
using BlazorDiscoveryAPI.Domain.Entities;
using BlazorDiscoveryAPI.Domain.Services;
using BlazorDiscoveryAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlazorDiscoveryAPI.Controllers
{
    [ApiController]
    [Route("v1/person")]    
    public class PersonManagementController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPersonRepository _personRepository;

        public PersonManagementController(IMediator mediator, IPersonRepository personRepository)
        {
            _mediator = mediator;
            _personRepository = personRepository;
        }

        [HttpGet("{id}")]
        public async Task<Person?> GetPerson(Guid id)
        {
            return await _personRepository.GetById(id);
        }

        [HttpGet]
        public async Task<IList<Person>> GetAllPerson()
        {
             return await _personRepository.Get();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson(CreatePersonRequest input)
        {
            var command = new CreatePersonCommand(
                input.Name,
                input.BirthDate,
                input.Document,
                new CreatePersonCommand.CreatePersonCommandAddress(
                    input.Address.Street,
                    input.Address.Number,
                    input.Address.City,
                    input.Address.State,
                    input.Address.ZipCode),
                input.Phone,
                input.Email
                );

            var result = await _mediator.Send(command);

            return result.Sucesso
                ? CreatedAtAction(nameof(CreatePerson), result)
                : BadRequest(result);
        }
    }
}
