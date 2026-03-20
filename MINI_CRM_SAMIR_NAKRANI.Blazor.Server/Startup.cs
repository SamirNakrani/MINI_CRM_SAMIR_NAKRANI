using DevExpress.ExpressApp.ApplicationBuilder;
using DevExpress.ExpressApp.Blazor.ApplicationBuilder;
using DevExpress.ExpressApp.Blazor.Services;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.Authentication;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Server.Circuits;
using MINI_CRM_SAMIR_NAKRANI.Blazor.Server.Services;

namespace MINI_CRM_SAMIR_NAKRANI.Blazor.Server
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
            services.AddSingleton(typeof(Microsoft.AspNetCore.SignalR.HubConnectionHandler<>), typeof(ProxyHubConnectionHandler<>));

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddLocalization();

            services.AddHttpContextAccessor();
            services.AddDevExpressBlazor();
            services.AddScoped<CircuitHandler, CircuitHandlerProxy>();
            services.AddRequestLocalization(options => {
                options.AddSupportedCultures("en-US", "ja-JP");
                options.AddSupportedUICultures("en-US", "ja-JP");
                options.SetDefaultCulture("en-US");
            });
            services.AddScoped<LoginHistoryService>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/LoginPage";
                });
            services.AddXaf(Configuration, builder =>
            {
                builder.UseApplication<MINI_CRM_SAMIR_NAKRANIBlazorApplication>();

                // ✅ MODULES
                builder.Modules

                    .AddAuditTrailXpo()
                    .AddConditionalAppearance()
                    .AddValidation(options =>
                    {
                        options.AllowValidationDetailsAccess = false;
                    })
                     .AddDashboards(options =>
                     {
                         options.DashboardDataType = typeof(DashboardData);
                     })
                    .Add<MINI_CRM_SAMIR_NAKRANI.Module.MINI_CRM_SAMIR_NAKRANIModule>()
                    .Add<MINI_CRM_SAMIR_NAKRANIBlazorModule>();

                builder.Security
    .UseIntegratedMode(options =>
    {
        options.RoleType = typeof(PermissionPolicyRole);
        options.UserType = typeof(PermissionPolicyUser);
    })
    .AddPasswordAuthentication(options =>   
    {
        options.IsSupportChangePassword = true;
    });
                builder.ObjectSpaceProviders
                    .AddXpo((serviceProvider, options) =>
                    {
                        string connectionString = Configuration.GetConnectionString("ConnectionString");

#if EASYTEST
    if (Configuration.GetConnectionString("EasyTestConnectionString") != null)
    {
        connectionString = Configuration.GetConnectionString("EasyTestConnectionString");
    }
#endif

                        ArgumentNullException.ThrowIfNull(connectionString);

                        options.ConnectionString = connectionString;
                        options.ThreadSafe = true;
                        options.UseSharedDataStoreProvider = true;
                    })
                    .AddNonPersistent();

            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRequestLocalization();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseXaf();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapXafEndpoints();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
                endpoints.MapControllers();
            });
        }
    }
}