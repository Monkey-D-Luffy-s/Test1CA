using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test1Core;

public static class DependencyInjection
{
    public static IServiceCollection AddTest1CoreServices(this IServiceCollection services)
    {
        return services;
    }
}

