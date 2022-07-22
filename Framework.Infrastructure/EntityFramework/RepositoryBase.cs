using AutoMapper;
using Framework.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Infrastructure.EntityFramework
{
    public abstract class RepositoryBase<TRepo, TDomain, TId> :IDisposable, IRepositoryBase<TDomain, TId>
        where TDomain : IDomainEntity where TRepo : class
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TRepo> _repo;
        protected readonly IMapper _map;

        protected RepositoryBase(DbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _repo = dbContext.Set<TRepo>();
            _map = mapper;
        }

        public async Task<int> Add(TDomain entity)
        {
            var dbEntity = _map.Map<TRepo>(entity);
            var rr = await _repo.AddAsync(dbEntity);
            return 1;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<TDomain> GetById(TId id)
        {
            var dbResult = await _repo.FindAsync(id);
            return _map.Map<TRepo, TDomain>(dbResult);
        }

        public async Task<TDomain> GetFirtsOfDefault()
        {
            return _map.Map<TDomain>(await _repo.FirstOrDefaultAsync());
        }

        public async Task<List<TDomain>> GetList()
        {
            var result = await _repo.ToListAsync();
            return _map.Map<List<TRepo>, List<TDomain>>(result);
        }

        public Task<List<TDomain>> GetList(int numberPage, int recordsPerPage)
        {
            var skipe = (numberPage - 1) * recordsPerPage;
            var result = _repo.AsQueryable().Skip(skipe).Take(recordsPerPage).ToList();
            return Task.FromResult(_map.Map<List<TDomain>>(result));
        }

        public Task<List<TDomain>> GetListByFilter(Func<object, bool> where)
        {
            var result = _repo.AsNoTracking().AsQueryable().Where(where);
            return Task.FromResult(_map.Map<List<TDomain>>(result.ToList())); ;
        }

        public async Task<int> SaveChancge()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public Task<int> Update(TDomain entity)
        {
            var dbEntity = _map.Map<TRepo>(entity);

            _repo.Update(dbEntity);

            return Task.FromResult(1);
        }
    }
}
