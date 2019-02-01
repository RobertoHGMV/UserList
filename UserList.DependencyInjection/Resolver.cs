using Microsoft.Extensions.DependencyInjection;
using UserList.Business.Services;
using UserList.Domain.Interfaces.Repositories;
using UserList.Domain.Interfaces.Services;
using UserList.Domain.Repositories;
using UserList.Infra.Contexts;
using UserList.Infra.Repositories;
using UserList.Infra.Transactions;

namespace UserList.DependencyInjection
{
    public class Resolver
    {
        public void Resolve(IServiceCollection services)
        {
            services.AddScoped<StoredDataContext, StoredDataContext>();
            services.AddTransient<IUow, Uow>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}