using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string ColorCode { get; set; }
        public double UsedQuantity { get; set; }
        public DateTime ExpDate { get; set; }
        public double TubeQuantity { get; set; }
        // public double TotalQuantity { get; set; }

       
        
      // public ColorFormula ColorFormula { get; set; }
    }
}
