using Microsoft.Extensions.DependencyInjection;
using src.Api.Domain.Interfaces.Services.Cep;
using src.Api.Domain.Interfaces.Services.Municipio;
using src.Api.Domain.Interfaces.Services.Uf;
using src.Api.Domain.Interfaces.Services.User;
using src.Api.Service.Services;

namespace src.Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<ILoginService, LoginService>();

            serviceCollection.AddTransient<IUfService, UfService>();
            serviceCollection.AddTransient<IMunicipioService, MunicipioService>();
            serviceCollection.AddTransient<ICepService, CepService>();
        }
    }
}
