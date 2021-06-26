using APIKalbe.DBContext;
using APIKalbe.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace APIKalbe
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

            services.AddDbContextPool<LanguageContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("KalbeDBConnectionString")));
            services.AddScoped<ILanguageService, LanguageService>();

            services.AddDbContextPool<CurrencyContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("KalbeDBConnectionString")));
            services.AddScoped<ICurrencyService, CurrencyServices>();

            services.AddDbContextPool<UOMContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("KalbeDBConnectionString")));
            services.AddScoped<IUOMServices, UOMServices>();

            services.AddDbContextPool<CustomerContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("KalbeDBConnectionString")));
            services.AddScoped<ICustomerService, CustomerService>();

            services.AddDbContextPool<NoSeriesContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("KalbeDBConnectionString")));
            services.AddScoped<INoSeriesService, NoSeriesService>();

            services.AddDbContextPool<POHeaderContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("KalbeDBConnectionString")));
            services.AddScoped<IPOHeaderService, POHeaderService>();

            services.AddDbContextPool<InvoiceContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("KalbeDBConnectionString")));
            services.AddScoped<IInvoiceService, InvoicesService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
