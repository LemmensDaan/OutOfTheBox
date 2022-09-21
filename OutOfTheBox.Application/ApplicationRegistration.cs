using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OutOfTheBox.Contracts.Commands;
using OutOfTheBox.Models.Entity.Cells;
using OutOfTheBox.Models.Entity.Prisoners;
using OutOfTheBox.Models.Entity.PrisonGroups;
using OutOfTheBox.Models.Entity.Prisons;
using System.Reflection;

namespace OutOfTheBox.Application;

public static class ApplicationRegistration
{
    public static void RegisterApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetAssembly(typeof(ApplicationRegistration)));

        AssemblyScanner.FindValidatorsInAssemblyContaining<CommandBase<IValidator>>()
            .ForEach(x =>
            {
                services.Add(ServiceDescriptor.Transient(x.InterfaceType, x.ValidatorType));
                services.Add(ServiceDescriptor.Transient(x.ValidatorType, x.ValidatorType));
            });
    }
}
