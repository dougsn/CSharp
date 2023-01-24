using AspNetCoreIdentity.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace AspNetCoreIdentity.Configs
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationHandler, PermissaoNecessariaHandler>(); // Realizando a injeção de dependência 

            return services;
        }


    }
}



