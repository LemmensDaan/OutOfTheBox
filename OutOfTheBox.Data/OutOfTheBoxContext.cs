using Microsoft.EntityFrameworkCore;
using OutOfTheBox.Models.Entity.Cells;
using OutOfTheBox.Models.Entity.Prisoners;
using OutOfTheBox.Models.Entity.PrisonGroups;
using OutOfTheBox.Models.Entity.Prisons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfTheBox.Data
{
    public class OutOfTheBoxContext : DbContext
    {
        public OutOfTheBoxContext(DbContextOptions<OutOfTheBoxContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public override int SaveChanges()
        {
            this.AddAuditInfo();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            this.AddAuditInfo();
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<PrisonGroup> PrisonGroups { get; set; } = null!;
        public DbSet<Prison> Prisons { get; set; } = null!;
        public DbSet<Cell> Cells  { get; set; } = null!;
        public DbSet<Prisoner> Prisoners { get; set; } = null!;
    }
}
