using Framework.UTest.EF.Map;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.UTest.EF
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<CtxTest>(options => options.UseSqlServer("Data Source=DESKTOP-05OT9V1;Initial Catalog=Lista69B;Persist Security Info=True;User ID=sa;Password=antonio"));
            serviceCollection.AddAutoMapper(typeof( CountryMap));
            //serviceCollection.AddTransient<>
            return serviceCollection;
        }
    }
}
