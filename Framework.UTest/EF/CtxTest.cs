using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.UTest.EF
{
    public  class CtxTest:DbContext
    {

        public CtxTest(DbContextOptions optionsBuilder) : base(optionsBuilder)
        {

        }
        public DbSet<CountryEntityEntity> countryEntityRepositories { get; set; }
        public DbSet<StateEntity> stateRepositories { get;set; }
    }
}
