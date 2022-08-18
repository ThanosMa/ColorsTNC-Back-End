﻿using System;
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
        public string Duration { get; set; }
        public double Cost { get; set; }
        public string ServiceType { get; set; } //Enum 
        //List of photos
        
  
      
        //nav prop
       // public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}