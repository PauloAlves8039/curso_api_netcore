using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using src.Api.CrossCutting.DependencyInjection;
using src.Api.Domain.Security;

namespace application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureService.ConfigureDependenciesService(services);
            ConfigureRepository.ConfigureDependencyRepository(services);

            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            var tokenConfigurations = new TokenConfigurations();
            new ConfigureFromConfigurationOptions<TokenConfigurations>(
                Configuration.GetSection("TokenConfigurations"))
                    .Configure(tokenConfigurations);
            services.AddSingleton(tokenConfigurations);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Curso de API com AspNetCore 3.1 - Na Prática",
                    Description = "Arquitetura DDD",
                    TermsOfService = new Uri("http://www.mfrinfo.com.br"),
                    Contact = new OpenApiContact
                    {
                        Name = "Marcos Fabricio Rosa",
                        Email = "mfr@mail.com",
                        Url = new Uri("http://www.mfrinfo.com.br")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Termo de Licença de Uso",
                        Url = new Uri("http://www.mfrinfo.com.br")
                    }
                }
                );
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Curso de API com AspNetCote 3.1");
                c.RoutePrefix = string.Empty;
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
