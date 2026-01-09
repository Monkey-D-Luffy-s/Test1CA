using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Test1Core.ServiceContracts;
using Test1Core.Services;
using FluentValidation;

// Fix for CS0246: Add missing using directives for MediatR types if you are using MediatR
// using MediatR; // Uncomment if IPipelineBehavior is from MediatR
 using Test1Core.Validators;
using MediatR; // Uncomment if LoginRequestValidator is in this namespace

namespace Test1Core;

public static class DependencyInjection
{
    public static IServiceCollection AddTest1CoreServices(this IServiceCollection services)
    {
        services.AddTransient<IUserService, UserService>();

        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();

        return services;
    }
}

