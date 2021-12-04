using AutoMapper;
using eUpisi.Api.Infrastructure.Extensions;
using TC.DomainModels;
using TC.Shared.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TenisClubApp
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
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("hr-HR");
                
            });
            services.AddMvc().AddRazorRuntimeCompilation();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            /************************************** NOVO DODANO ******************************************/
            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("StudentManagerDbContext")));
            //services.AddIdentity<Employee, IdentityRole>().AddRoleManager<RoleManager<IdentityRole>>().AddDefaultUI()
            //    .AddDefaultTokenProviders().AddEntityFrameworkStores<ApplicationDbContext>();

            /********************************************************************************/

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();

            services.RegisterTrackableRepositories();
            services.RegisterServices();
            services.Configure<CookiePolicyOptions>(options => {
                options.CheckConsentNeeded = context => true;
            });

            services.AddHttpContextAccessor();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(new[] {
                        "TC.Services"
                    });
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseRequestLocalization();
            app.UseExceptionMiddleware();

            app.UseDeveloperExceptionPage();
            app.UseMigrationsEndPoint();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}

