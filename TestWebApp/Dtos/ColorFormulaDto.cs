using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebApp.Dtos
{
    public class ColorFormulaDto
    {
        public int Id { get; set; }
        public string FormulaName { get; set; }
        public DateTime CreationDate { get; set; }
        public double Cost { get; set; }
        public string Duration { get; set; }
        public string ServiceType { get; set; }
        public ICollection<Product> Products { get; set; }
        //IEnumerable

    }
}