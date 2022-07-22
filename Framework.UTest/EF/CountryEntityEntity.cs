using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.UTest.EF
{
    public class CountryEntityEntity
    {
        [Key]
        public int Id { get; set; } 
        public string name { get; set; }
    }
}
