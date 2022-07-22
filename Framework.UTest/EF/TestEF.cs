using AutoMapper;
using Framework.UTest.EF.Interface;
using Framework.UTest.EF.Map;
using Framework.UTest.EF.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.UTest.EF
{
    public class TestEF
    {
        private IServiceCollection serviceCollection;
        private ServiceProvider serviceProvider;
        private ICountryRepository _repo;
        private IStateRepository _repoState;
        [SetUp]
        public void Setup()
        {
             serviceCollection = new ServiceCollection();
            serviceCollection.AddServices();

             serviceProvider = serviceCollection.BuildServiceProvider();

        }

        [Test]
        public    void AddCountry()
        {
            _repo = new CountryRepository(serviceProvider.GetServices<CtxTest>().FirstOrDefault(), serviceProvider.GetServices<IMapper>().FirstOrDefault());

              _repo.Add(new Domain.Country() { Name = "Mexico" }).Wait();
              _repo.SaveChancge().Wait();
            
            Assert.Pass();
        }

        [Test]
        public void UpdatedCountry()
        {
            _repo = new CountryRepository(serviceProvider.GetServices<CtxTest>().FirstOrDefault(), serviceProvider.GetServices<IMapper>().FirstOrDefault());

            _repo.Update(new Domain.Country() { CountryID=1, Name = "Mexico1" }).Wait();
            _repo.SaveChancge().Wait();
            Assert.Pass();
        }

        [Test]
        public void AddState()
        {
            _repo = new CountryRepository(serviceProvider.GetServices<CtxTest>().FirstOrDefault(), serviceProvider.GetServices<IMapper>().FirstOrDefault());
            _repoState= new StateRepository (serviceProvider.GetServices<CtxTest>().FirstOrDefault(), serviceProvider.GetServices<IMapper>().FirstOrDefault());

            var countrys = _repo.GetList().Result.FirstOrDefault();
            if (countrys is null)
            {
                Assert.Fail();
            }

            
             var i=_repoState.Add(new Domain.State("estado de mexico", countrys)).Result;
            _repoState.SaveChancge().Wait();
            Assert.Pass();
        }

        [Test]
        public void GetAllState()
        {
            _repoState = new StateRepository(serviceProvider.GetServices<CtxTest>().FirstOrDefault(), serviceProvider.GetServices<IMapper>().FirstOrDefault());
            _repo = new CountryRepository(serviceProvider.GetServices<CtxTest>().FirstOrDefault(), serviceProvider.GetServices<IMapper>().FirstOrDefault());
            var result =_repoState.GetList().Result;

            

            Assert.Pass();
        }

        [Test]
        public void GetAllbyState()
        {
            _repoState = new StateRepository(serviceProvider.GetServices<CtxTest>().FirstOrDefault(), serviceProvider.GetServices<IMapper>().FirstOrDefault());
            var result = _repoState.GetById(1).Result;

            if (result is null)
                Assert.Fail();

            Assert.Pass();
        }

        [Test]
        public void GetFirtOfDefault()
        {
            _repoState = new StateRepository(serviceProvider.GetServices<CtxTest>().FirstOrDefault(), serviceProvider.GetServices<IMapper>().FirstOrDefault());
            var result = _repoState.GetFirtsOfDefault().Result;

            if (result.StateId==0)
                Assert.Fail();

            Assert.Pass();

        }

        [Test]
        public void GetAllPaginationState()
        {
            _repoState = new StateRepository(serviceProvider.GetServices<CtxTest>().FirstOrDefault(), serviceProvider.GetServices<IMapper>().FirstOrDefault());
            var result = _repoState.GetList(1,1).Result;

            Assert.Pass();
        }

        [Test]
        public void GetListByFilter()
        {
            _repoState = new StateRepository(serviceProvider.GetServices<CtxTest>().FirstOrDefault(), serviceProvider.GetServices<IMapper>().FirstOrDefault());
            var result = _repoState.GetListByFilter(x=>((StateEntity)x).CountryId==5).Result;

            Assert.Pass();
        }

    }
}
