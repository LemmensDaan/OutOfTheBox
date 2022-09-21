using OutOfTheBox.Models.Entity.Cells;
using OutOfTheBox.Models.Entity.Prisoners;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfTheBox.Models.Entity.Prisons
{
    public class Prison : BaseAuditableEntity
    {
        [Required]
        public string Name { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }
        public string? Phone { get; set; }

        #region Address
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Zip { get; set; }
        public string? Street { get; set; }
        public string? Nr { get; set; }
        #endregion
        public virtual ICollection<Cell> Cells { get; private set; } = new HashSet<Cell>();
        public virtual ICollection<Prisoner> Prisoners { get; private set; } = new HashSet<Prisoner>();

        public bool IsDeleted { get; private set; }

        public Prison(string name)
        {
            this.Name = name;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
