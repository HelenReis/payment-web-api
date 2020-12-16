using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Payment.Data;
using Payment.Data.Repositories;
using Payment.Data.Repositories.Transaction.UnitOfWork;
using Payment.Service.Comandos.Contract;
using Payment.Service.Comandos.FinancialPostingCommand.ImportFile;

namespace Payment.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            /*COLOCAR NUMA CONNECTION STRING*/
            /* VERIFICAR PROBLEMA DOCKER NO MYSQL PROVIDER */
            services.AddDbContext<PaymentContext>(options => 
                options.UseMySQL("server = localhost; port = 3306; database = payment; Uid = root; Pwd = root;"));

            // Repositórios
            services.AddTransient<IBankAccountRepository, BankAccountRepository>();
            services.AddTransient<IBankRepository, BankRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IFinancialPostingRepository, FinancialPostingRepository>();

            // Serviços
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //Comandos e Consultas
            services.AddTransient<ICommandService<ImportFileParams, ImportFileResult>, ImportFile>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
