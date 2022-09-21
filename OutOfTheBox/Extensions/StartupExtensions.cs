
using OutOfTheBox.Models.Entity.Cells;
using OutOfTheBox.Models.Entity.Prisoners;
using OutOfTheBox.Models.Entity.PrisonGroups;
using OutOfTheBox.Models.Entity.Prisons;
using OutOfTheBox.Repositories;

namespace OutOfTheBox.Web;

public static class StartupExtensions
{
    public static void RegisterDependencies(this IServiceCollection services)
    {
        services.AddTransient<IRepository<PrisonGroup>, Repository<PrisonGroup>>();
        services.AddTransient<IRepository<Prison>, Repository<Prison>>();
        services.AddTransient<IRepository<Cell>, Repository<Cell>>();
        services.AddTransient<IRepository<Prisoner>, Repository<Prisoner>>();
    }
}
