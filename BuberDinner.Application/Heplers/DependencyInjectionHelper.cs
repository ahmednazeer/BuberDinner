using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Application.Services.Authentication;

namespace BuberDinner.Application.Heplers
{
    public static class DependencyInjectionHelper
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection  services){
            services.AddScoped<IAuthService,AuthService>();
            return services;
        }
    }
}