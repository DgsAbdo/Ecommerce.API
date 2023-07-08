using Ecommerce.Domain.Services;
using Ecommerce.Domain.Repositories;
using Ecommerce.Infra.Context;
using Ecommerce.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Api
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
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
            //services.AddDbContext<DataContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("connectionString")));

            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<ProdutoService, ProdutoService>();

            services.AddTransient<IPromocaoRepository, PromocaoRepository>();
            services.AddTransient<PromocaoService, PromocaoService>();

            services.AddTransient<ICarrinhoRepository, CarrinhoRepository>();
            services.AddTransient<CarrinhoService, CarrinhoService>();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
