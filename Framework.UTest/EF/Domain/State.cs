using Framework.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.UTest.EF.Domain
{
    public class State:IDomainEntity
    {
        public State(string name, Country country)
        {
            Name = name;
            CountryId = country.CountryID;
        }

        public State(int stateId, string name, int countryId)
        {
            StateId = stateId;
            Name = name;
            CountryId = countryId;
        }



        public int StateId { get; set; }
        public string Name { get;  }

        public int CountryId { get; }
        public Country Country { get; }


    }
}
