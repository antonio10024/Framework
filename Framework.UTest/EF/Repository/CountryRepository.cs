using AutoMapper;
using Framework.Infrastructure.EntityFramework;
using Framework.UTest.EF.Domain;
using Framework.UTest.EF.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.UTest.EF.Repository
{
    public class CountryRepository : RepositoryBase<CountryEntityEntity, Country, int>, ICountryRepository
    {
        public CountryRepository(DbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }
    }
}
