using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain.Interfaces
{
    public interface IRepositoryBase<TDomain,TId>  where TDomain:IDomainEntity 
    {
        public Task<int> Add(TDomain entity);

        public Task<int> Update(TDomain entity);
        public Task<TDomain> GetById(TId id);
        public Task<List<TDomain>> GetListByFilter(Func<Object,bool> where) ;
        public Task<List<TDomain>> GetList();
        public Task<List<TDomain>> GetList(int numberPage, int RecordsPerPage);

        public Task<TDomain> GetFirtsOfDefault();

        public Task<int> SaveChancge();
    }
}
