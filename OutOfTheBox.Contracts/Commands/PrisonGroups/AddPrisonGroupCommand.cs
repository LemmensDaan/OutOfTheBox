using FluentValidation;
using OutOfTheBox.Models.Entity.PrisonGroups;
using OutOfTheBox.Models.Entity.Prisons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfTheBox.Contracts.Commands.PrisonGroups
{
    public class AddPrisonGroupCommandValidator : AbstractValidator<AddPrisonGroupCommand>
    {
        public AddPrisonGroupCommandValidator()
        {
            RuleFor(pg => pg.Name).NotEmpty();
            RuleFor(pg => pg.Email).NotEmpty();
        }
    }
    public class AddPrisonGroupCommand : CommandBase<PrisonGroup>
    {
        public string Name { get; set; }
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
