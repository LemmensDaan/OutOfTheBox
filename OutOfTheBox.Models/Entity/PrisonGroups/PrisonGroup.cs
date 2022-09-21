using OutOfTheBox.Models.Entity.Prisons;
using System.ComponentModel.DataAnnotations;

namespace OutOfTheBox.Models.Entity.PrisonGroups
{
    public class PrisonGroup : BaseAuditableEntity
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
        public bool IsDeleted { get; private set; }
        
        public virtual ICollection<Prison> Prisons { get; private set; } = new HashSet<Prison>();

        public PrisonGroup(string name)
        {
            Name = name;
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
