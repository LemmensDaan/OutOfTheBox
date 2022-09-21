using FluentValidation;
using FluentValidation.Results;
using MediatR;
using OutOfTheBox.Contracts.Commands.PrisonGroups;
using OutOfTheBox.Models.Entity.PrisonGroups;
using OutOfTheBox.Repositories;
namespace Stoelendans.Application.CommandHandlers.PrisonGroups;

public class UpdatePrisonGroupCommandHandler : IRequestHandler<UpdatePrisonGroupCommand, PrisonGroup>
{
    private readonly IRepository<PrisonGroup> _repository;
    private readonly PrisonGroup _prisonGroups;

    public UpdatePrisonGroupCommandHandler(IRepository<PrisonGroup> repository, PrisonGroup prisonGroup)
    {
        _repository = repository;
        _prisonGroups = prisonGroup;
    }
    public async Task<PrisonGroup> Handle(UpdatePrisonGroupCommand request, CancellationToken cancellationToken)
    {
        ValidationResult result = await new UpdatePrisonGroupCommandValidator().ValidateAsync(request);
        if (!result.IsValid)
            throw new ValidationException(result.Errors);

        PrisonGroup pg = await _repository.GetAsync(pg => pg.Id == request.Id && pg.IsDeleted == false);

        if (!string.IsNullOrEmpty(request.Name)) pg.Name = request.Name;
        if (!string.IsNullOrEmpty(request.Email)) pg.Email = request.Email;
        if (!string.IsNullOrEmpty(request.Phone)) pg.Phone = request.Phone;
        if (!string.IsNullOrEmpty(request.Country)) pg.Country = request.Country;
        if (!string.IsNullOrEmpty(request.City)) pg.City = request.City;
        if (!string.IsNullOrEmpty(request.Zip)) pg.Zip = request.Zip;
        if (!string.IsNullOrEmpty(request.Street)) pg.Street = request.Street;
        if (!string.IsNullOrEmpty(request.Nr)) pg.Nr = request.Nr;

        _repository.Update(pg);
        await _repository.SaveChangesAsync();

        return pg;
    }
}
