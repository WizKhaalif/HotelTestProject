using AuthorizationSystem.Domain.Abstractions;
using AuthorizationSystem.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AuthorizationSystem.Domain
{
    public static class DomainExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection collection)
        {
            collection.AddScoped<IUserService, UserService>();
            return collection;
        }
    }
}
