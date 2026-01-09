using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Test1Core.RepositoryContracts;
using Test1Infrastructure.Repositories;
using Test1Infrastructure.UserContext;

namespace Test1Infrastructure;

public static class DependencyInjuctions 
{
    public static IServiceCollection AddTest1InfrastructureServices(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();

        services.AddTransient<UserDbContext>();
        return services;
    }
}

