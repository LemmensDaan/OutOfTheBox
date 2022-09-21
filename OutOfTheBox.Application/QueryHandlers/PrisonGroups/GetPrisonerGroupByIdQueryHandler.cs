using MediatR;
using OutOfTheBox.Contracts.Queries.PrisonGroups;
using OutOfTheBox.Models.Entity.PrisonGroups;
using OutOfTheBox.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfTheBox.Application.QueryHandlers.PrisonGroups
{
    public class GetPrisonerGroupByIdQueryHandler : IRequestHandler<GetPrisonGroupByIdQuery, PrisonGroup>
    {
        private readonly IRepository<PrisonGroup> _repository;
        private readonly PrisonGroup _prisonGroup;

        public GetPrisonerGroupByIdQueryHandler(IRepository<PrisonGroup> repository, PrisonGroup prisonGroup)
        {
            _repository = repository;
            _prisonGroup = prisonGroup;
        }
        public async Task<PrisonGroup> Handle(GetPrisonGroupByIdQuery request, CancellationToken cancellationToken)
        {
            var prisonGroup = await _repository.GetAsync(pg => pg.IsDeleted == false && pg.Id == request.Id);
            if (prisonGroup == null)
            {
                //TODO : throw notfound exception
            }
            return prisonGroup;
        }
    }
}
