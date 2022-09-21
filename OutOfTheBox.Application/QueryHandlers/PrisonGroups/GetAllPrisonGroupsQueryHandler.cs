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
    public class GetAllPrisonGroupsQueryHandler : IRequestHandler<GetAllPrisonGroupsQuery, IEnumerable<PrisonGroup>>
    {
        private readonly IRepository<PrisonGroup> _repository;
        private readonly PrisonGroup _prisonGroup;

        public GetAllPrisonGroupsQueryHandler(IRepository<PrisonGroup> repository, PrisonGroup prisonGroup)
        {
            _repository = repository;
            _prisonGroup = prisonGroup;
        }
        public async Task<IEnumerable<PrisonGroup>> Handle(GetAllPrisonGroupsQuery request, CancellationToken cancellationToken)
        {
            var prisonGroups = await _repository.GetListAsync(pg => pg.IsDeleted == false);
            if (prisonGroups == null)
            {
                //TODO : throw notfound exception
            }
            return prisonGroups;
        }
    }
}
