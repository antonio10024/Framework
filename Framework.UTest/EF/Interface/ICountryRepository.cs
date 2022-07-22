using Framework.Domain.Interfaces;
using Framework.UTest.EF.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.UTest.EF.Interface
{
    public interface ICountryRepository: IRepositoryBase<Country,int>
    {
    }
}
