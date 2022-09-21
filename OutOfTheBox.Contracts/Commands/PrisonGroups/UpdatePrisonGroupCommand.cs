using FluentValidation;
using OutOfTheBox.Models.Entity.PrisonGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfTheBox.Contracts.Commands.PrisonGroups
{
    public class UpdatePrisonGroupCommandValidator : AbstractValidator<UpdatePrisonGroupCommand>
    {
        public UpdatePrisonGroupCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
        }
    }
    public class UpdatePrisonGroupCommand : CommandBase<PrisonGroup>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        #region Address

        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Zip { get; set; }
        public string? Street { get; set; }
        public string? Nr { get; set; }

        #endregion
    }
}
