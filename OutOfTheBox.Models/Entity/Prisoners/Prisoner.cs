using OutOfTheBox.Models.Entity.Prisons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfTheBox.Models.Entity.Prisoners
{
    public class Prisoner : BaseAuditableEntity, IPrisonerBehavior
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName{ get; set; }
        [Required]
        public string SSN { get; set; }
        [Required]
        public int PrisonerNumber { get; set; }
        [Required]
        public char Gender { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        public virtual Prison Prison { get; set; }
        public bool IsDeleted { get; private set; }
        public bool IsOnGoodBehavior { get; set; }

        public Prisoner(string firstName, string lastName, string sSN, int prisonerNumber, DateTime releaseDate)
        {
            FirstName = firstName;
            LastName = lastName;
            SSN = sSN;
            PrisonerNumber = prisonerNumber;
            ReleaseDate = releaseDate;
        }

        public void Delete()
        {
            IsDeleted = true;
        }

        public void ChangePrisonerBehaviour(bool GoodBehaviour)
        {
            this.IsOnGoodBehavior = GoodBehaviour;
        }
    }
}
