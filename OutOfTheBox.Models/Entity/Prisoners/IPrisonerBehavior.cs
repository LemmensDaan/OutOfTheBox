using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfTheBox.Models.Entity.Prisoners
{
    public interface IPrisonerBehavior
    {
        public void ChangePrisonerBehaviour(bool GoodBehaviour);
    }
}
