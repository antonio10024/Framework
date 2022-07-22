using AutoMapper;
using Framework.UTest.EF.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.UTest.EF.Map
{
    public class CountryMap : Profile
    {
        public CountryMap()
        {
            CreateMap<CountryEntityEntity, Country>().
                ForMember(des => des.CountryID, so => so.MapFrom(s => s.Id));

            CreateMap<Country, CountryEntityEntity>().
                ForMember(des => des.Id, so => so.MapFrom(s => s.CountryID));

            CreateMap<StateEntity, State>().
                ConstructUsing(x => new State(x.StateId, x.StateName, x.CountryId));

            CreateMap<State, StateEntity>().
                ForMember(des => des.StateName, so => so.MapFrom(s => s.Name));

        }
    }
}
