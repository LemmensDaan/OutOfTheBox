using FluentValidation;
using FluentValidation.Results;
using MediatR;
using OutOfTheBox.Contracts.Commands.PrisonGroups;
using OutOfTheBox.Models.Entity.PrisonGroups;
using OutOfTheBox.Repositories;

namespace OutOfTheBox.Application.CommandHandlers.PrisonGroups
{
    public class AddPrisonGroupCommandHandler : IRequestHandler<AddPrisonGroupCommand, PrisonGroup>
    {
        private readonly IRepository<PrisonGroup> _repository;
        private readonly PrisonGroup _prisonGroup;

        public AddPrisonGroupCommandHandler(IRepository<PrisonGroup> repository, PrisonGroup prisonGroup)
        {
            _repository = repository;
            _prisonGroup = prisonGroup;
        }

        public async Task<PrisonGroup> Handle(AddPrisonGroupCommand request, CancellationToken cancellationToken)
        {
            ValidationResult result = await new AddPrisonGroupCommandValidator().ValidateAsync(request);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            PrisonGroup pg = new PrisonGroup(request.Name)
            {

                Email = request.Email,
                Phone = request.Phone,
                Country = request.Country,
                City = request.City,
                Zip = request.Zip,
                Street = request.Zip,
                Nr = request.Nr
            };
            _repository.Add(pg);
            await _repository.SaveChangesAsync();

            return pg;
        }
    }
}
