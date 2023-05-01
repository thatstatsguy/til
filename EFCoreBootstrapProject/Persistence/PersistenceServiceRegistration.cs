using Application.Contracts.Persistence;
using Domain;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<BootstrapDbContext>();
        services.AddScoped<IRepository<Book>, BookRepository>();
        return services;
    }
}