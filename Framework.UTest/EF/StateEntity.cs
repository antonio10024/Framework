using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.UTest.EF
{
    public class StateEntity
    {
        [Key]
        public int StateId { get; set; }
        public string StateName { get; set; }

        public int CountryId { get; set; }
        public CountryEntityEntity Country { get; set; }
    }
}
