using AnotaAi.Dominio.Interface.Respositorios.Comandas;
using AnotaAi.Dominio.Interface.Respositorios.Funcionarios;
using AnotaAi.Dominio.Interface.Respositorios.Produtos;

using AnotaAi.Repositorio.Contexto;
using AnotaAi.Repositorio.Repositorios.Comandas;
using AnotaAi.Repositorio.Repositorios.Funcionarios;
using AnotaAi.Repositorio.Repositorios.Produtos;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace AnotaAi.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {           
            var connectionString = Configuration.GetConnectionString("AnotaAiDataBase");

            services.AddDbContext<AppDbContext>(option =>
                                                option.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            /* Comandas */
            services.AddScoped<IComandaRepositorio, ComandaRepositorio>();
            services.AddScoped<IItemComandaRepositorio, ItemComandaRepositorio>();
            services.AddScoped<IStatusRepositorio, StatusRepositorio>();

            /* Funcionarios */
            services.AddScoped<ICargoRepositorio, CargoRepositorio>();
            services.AddScoped<IFuncionarioRepositorio, FuncionarioRepositorio>();
            services.AddScoped<IPessoaRepositorio, PessoaRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            /* Produtos */
            services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "AnotaAi",
                    Version = "v1",
                    Description = "Projeto de comanda eletronica com ASP.Net Core - Web Api."
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AnotaAi - API");
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}