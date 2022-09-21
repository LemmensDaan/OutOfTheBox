using OutOfTheBox.Models.Entity.PrisonGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfTheBox.Contracts.Queries.PrisonGroups
{
    public class GetPrisonGroupByIdQuery : QueryBase<PrisonGroup>
    {
        public Guid Id { get; set; }
        public GetPrisonGroupByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
