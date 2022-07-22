using Framework.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.UTest.EF.Domain
{
    public class Country:IDomainEntity
    {
        public int CountryID { get; set; }
        public string Name { get; set; }
    }
}
