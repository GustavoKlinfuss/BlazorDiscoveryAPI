using BlazorDiscoveryAPI.Application.Commands;
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

        public PersonManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpGet("{id}")]
        //public async Task GetPerson(Guid id)
        //{
            
        //}

        //[HttpGet]
        //public async Task GetAllPerson()
        //{
            
        //}

        [HttpPost]
        public async Task<IActionResult> CreatePerson(CreatePersonRequest input)
        {
            var command = new CreatePersonCommand(
                input.Name,
                DateOnly.FromDateTime(input.BirthDate),
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
