using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Reflection.Metadata;

namespace Entities.Models
{
    public class ColorFormula
    {
        public int ColorFormulaID { get; set; }
        public string FormulaName { get; set; }
        public DateTime CreationDate { get; set; }
        public double Cost { get; set; }
        public string Duration { get; set; }
        public string ServiceType { get; set; }
        public int FormulasPhotosid { get; set; }
        public string FormulasPhotosUrl { get; set; }
        
        public virtual ICollection<Product> Products { get; set; }
        //public string Brand { get; set; }


       
    }
}