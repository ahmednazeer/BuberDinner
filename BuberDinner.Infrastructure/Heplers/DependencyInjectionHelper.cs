using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Application.Common;
using BuberDinner.Infrastructure.Authentication;
using Microsoft.Extensions.Configuration;
using BuberDinner.Infrastructure.Persistence;
using BuberDinner.Application.Services.Persistence;

namespace BuberDinner.Infrastructure.Heplers
{
    public static class DependencyInjectionHelper
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection  services){
            services.AddSingleton<IAuthTokenGenerator, AuthTokenGenerator>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}