using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data1.Models
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MapUrl { get; set; }
        public int CountryId { get; set; }  
        public virtual Country Country { get; set; }
    }
}
