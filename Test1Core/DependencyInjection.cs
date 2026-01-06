using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Test1Core.ServiceContracts;
using Test1Core.Services;

namespace Test1Core;

public static class DependencyInjection
{
    public static IServiceCollection AddTest1CoreServices(this IServiceCollection services)
    {
        services.AddTransient<IUserService, UserService>();
        return services;
    }
}

