using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfTheBox.Models.Entity.Cells
{
    public class IsolationCell : Cell
    {
        public IsolationCell()
        {
            this.ChangeAvailability(true);
            this.Spaces = 1;
        }
    }
}
