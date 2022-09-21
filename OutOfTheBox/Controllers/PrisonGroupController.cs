using MediatR;
using Microsoft.AspNetCore.Mvc;
using OutOfTheBox.Contracts.Commands.PrisonGroups;
using OutOfTheBox.Contracts.Queries.PrisonGroups;

namespace OutOfTheBox.Web.Controllers
{
    public class PrisonGroupController : ApiControllerBase
    {
        public PrisonGroupController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetPrisonGroups()
        {
            return await ExecuteRequest(new GetAllPrisonGroupsQuery());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrisonGroupById(string id)
        {
            return await ExecuteRequest(new GetPrisonGroupByIdQuery(Guid.Parse(id)));
        }

        [HttpPost]
        public async Task<IActionResult> PostPrisonGroup(AddPrisonGroupCommand command)
        {
            if (command == null) return BadRequest();
            return await ExecuteRequest(command);
        }

        [HttpPut]
        public async Task<IActionResult> PutPrisonGroup(UpdatePrisonGroupCommand command)
        {
            if (command == null) return BadRequest();
            return await ExecuteRequest(command);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePrisonGroup(DeletePrisonGroupCommand command)
        {
            if (command == null) return BadRequest();
            return await ExecuteRequest(command);
        }
    }
}
