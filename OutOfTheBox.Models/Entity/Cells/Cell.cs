
namespace OutOfTheBox.Models.Entity.Cells
{
    public abstract class Cell : BaseAuditableEntity
    {
        public int Spaces { get; set; }
        public bool Available { get; private set; }

        public bool IsDeleted { get; private set; }

        public void ChangeAvailability(bool availability)
        {
            Available = availability;
        }

        public void Delete()
        {
            IsDeleted = true;
        }

    }
}
