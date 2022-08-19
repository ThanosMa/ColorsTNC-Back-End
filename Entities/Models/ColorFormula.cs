using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class ColorFormula
    {
        public int ColorFormulaID { get; set; }
        public string FormulaName { get; set; }
        public DateTime CreationDate { get; set; }
        //public List<int> ProductIds { get; set; }
        //public string Brand { get; set; }
    }
}