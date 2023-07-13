﻿using Domain;
using Microsoft.AspNetCore.Identity;
using Persistence;

namespace Api.Extensions;

public static class IdentityServiceExtendion
{

    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddIdentityCore<AppUser>(opt =>
        {
            opt.Password.RequireNonAlphanumeric = false;
        })
        .AddEntityFrameworkStores<DataContext>()
        .AddSignInManager<SignInManager<AppUser>>();

        return services;
    }
}