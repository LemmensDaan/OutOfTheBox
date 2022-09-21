using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfTheBox.Models.Entity.Cells
{
    public class SmallCell : Cell
    {
        public SmallCell()
        {
            this.ChangeAvailability(true);
            this.Spaces = 1;
        }
    }
}
