using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfTheBox.Models
{
    public abstract class BaseAuditableEntity : BaseEntity
    {
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }
        [DataType(DataType.Date)]
        public DateTime Modified { get; set; }
    }
}
