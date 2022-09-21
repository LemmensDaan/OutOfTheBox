using FluentValidation;
using OutOfTheBox.Models.Entity.PrisonGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfTheBox.Contracts.Commands.PrisonGroups
{
    public class DeletePrisonGroupCommandValidator : AbstractValidator<DeletePrisonGroupCommand>
    {
        public DeletePrisonGroupCommandValidator()
        {
            
            RuleFor(c => c.Id).NotEmpty();
        }
    }
    public class DeletePrisonGroupCommand : CommandBase<PrisonGroup>
    {
        public Guid Id { get; set; }
    }
}
