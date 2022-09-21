using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfTheBox.Models.Entity.Cells
{
    public class BigCell : Cell
    {
        public BigCell()
        {
            this.ChangeAvailability(true);
            this.Spaces = 3;
        }

        
    }
}
