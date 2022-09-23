using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class WarehouseProduct
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string ColorCode { get; set; }
        public int TubeQuantity { get; set; }
        public int TotalQuantity { get; set; }

        //public virtual ICollection<ColorFormula> Formulas { get; set; }
    }
}
