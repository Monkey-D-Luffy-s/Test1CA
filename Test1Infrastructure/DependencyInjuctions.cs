using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test1Infrastructure;

public static class DependencyInjuctions 
{
    public static IServiceCollection AddTest1InfrastructureServices(this IServiceCollection services)
    {
        return services;
    }
}

