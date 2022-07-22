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
    public class StateRepository : RepositoryBase<StateEntity, State, int>, IStateRepository
    {
        public StateRepository(DbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            
        }
    }
}
