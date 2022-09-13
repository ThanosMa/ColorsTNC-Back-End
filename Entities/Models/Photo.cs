using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public string LocalFileName { get; set; }
    }
}
