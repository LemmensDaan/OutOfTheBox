using FluentValidation;
using FluentValidation.Results;
using MediatR;
using OutOfTheBox.Contracts.Commands.PrisonGroups;
using OutOfTheBox.Models.Entity.PrisonGroups;
using OutOfTheBox.Repositories;

namespace OutOfTheBox.Application.CommandHandlers.PrisonGroups
{
    public class DeletePrisonGroupCommandHandler : IRequestHandler<DeletePrisonGroupCommand, PrisonGroup>
    {
        private readonly IRepository<PrisonGroup> _repository;
        private readonly PrisonGroup _prisonGroup;

        public DeletePrisonGroupCommandHandler(IRepository<PrisonGroup> repository, PrisonGroup prisonGroup)
        {
            _repository = repository;
            _prisonGroup = prisonGroup;
        }

        public async Task<PrisonGroup> Handle(DeletePrisonGroupCommand request, CancellationToken cancellationToken)
        {
            ValidationResult result = await new DeletePrisonGroupCommandValidator().ValidateAsync(request);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            PrisonGroup pg = await _repository.GetAsync(pg => pg.Id == request.Id && pg.IsDeleted == false);
            _repository.Delete(pg);
            await _repository.SaveChangesAsync();

            return pg;
        }
    }
}
