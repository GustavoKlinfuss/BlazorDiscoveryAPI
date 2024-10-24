using BlazorDiscoveryAPI.Application.Base;
using BlazorDiscoveryAPI.Application.Commands.Outputs;
using BlazorDiscoveryAPI.Domain.Entities;
using BlazorDiscoveryAPI.Domain.Services;
using MediatR;

namespace BlazorDiscoveryAPI.Application.Commands.Handlers
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, BaseResult>
    {
        private readonly IPersonRepository _personRepository;

        public CreatePersonCommandHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<BaseResult> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = new Person(
                request.Name,
                request.BirthDate,
                request.Document,
                new Address(
                    request.Address.Street,
                    request.Address.Number,
                    request.Address.City,
                    request.Address.State,
                    request.Address.ZipCode),
                request.Phone,
                request.Email

                );
            await _personRepository.Create(person);
            await _personRepository.Commit();

            return new BaseResult(new CreatePersonCommandOutput(person));
        }
    }
}
