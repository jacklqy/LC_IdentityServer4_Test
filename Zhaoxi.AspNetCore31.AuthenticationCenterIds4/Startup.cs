using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Zhaoxi.AspNetCore31.AuthenticationCenterIds4.DataInit;
using Zhaoxi.AspNetCore31.AuthenticationCenterIds4.DataInit.DB;
using Zhaoxi.AspNetCore31.AuthenticationCenterIds4.Utility;

/// <summary>
/// https://github.com/IdentityServer/IdentityServer4.Quickstart.UI
/// dotnet new - i identityserver4.templates
/// dotnet new is4ui
/// http://localhost:7200/.well-known/openid-configuration
///
/// dotnet Zhaoxi.AspNetCore31.AuthenticationCenterIds4.dll –-urls=http://*:7200
/// </summary>
namespace Zhaoxi.AspNetCore31.AuthenticationCenterIds4
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
            //配置同一站点cookie不中断问题
            services.ConfigureNonBreakingSameSiteCookies();
            //services.AddControllers();
            services.AddControllersWithViews();

            #region 客户端
            //services.AddIdentityServer()//怎么处理
            //  .AddDeveloperSigningCredential()//默认的开发者证书--临时证书--生产环境为了保证token不失效，证书是不变的
            //  .AddInMemoryClients(ClientInitConfig.GetClients())//InMemory 内存模式
            //  .AddInMemoryApiResources(ClientInitConfig.GetApiResources());//能访问啥资源
            #endregion

            #region 密码模式
            //services.AddIdentityServer()
            //    .AddDeveloperSigningCredential()//默认的开发者证书 
            //   .AddInMemoryApiResources(PasswordInitConfig.GetApiResources())//API访问授权资源
            //   .AddInMemoryClients(PasswordInitConfig.GetClients())  //客户端
            //   .AddTestUsers(PasswordInitConfig.GetUsers());//添加用户
            #endregion

            #region 隐藏模式
            //services.AddIdentityServer()
            //    .AddDeveloperSigningCredential()//默认的开发者证书 
            //   .AddInMemoryApiResources(ImplicitInitConfig.GetApiResources()) //API访问授权资源
            //   .AddInMemoryClients(ImplicitInitConfig.GetClients())//客户端
            //   .AddTestUsers(ImplicitInitConfig.GetUsers()); //添加用户
            #endregion

            #region Code模式
            //services.AddIdentityServer()
            //    .AddDeveloperSigningCredential()//默认的开发者证书 
            //   .AddInMemoryApiResources(CodeInitConfig.GetApiResources()) //API访问授权资源
            //   .AddInMemoryClients(CodeInitConfig.GetClients())//客户端
            //   .AddTestUsers(CodeInitConfig.GetUsers()); //添加用户
            #endregion

            #region Hybrid模式
            //services.AddIdentityServer()
            //    .AddDeveloperSigningCredential()//默认的开发者证书 
            //    .AddInMemoryIdentityResources(HybridInitConfig.GetIdentityResources())//身份信息授权资源
            //   .AddInMemoryApiResources(HybridInitConfig.GetApiResources()) //API访问授权资源
            //   .AddInMemoryClients(HybridInitConfig.GetClients())//客户端
            //   .AddTestUsers(HybridInitConfig.GetUsers()); //添加用户
            #endregion

            #region 密码模式+EFCore
            //#region 将identityserver4的一些权限配置持久化到数据库(注意此处通过Migration初始化数据库的顺序，不然就要采坑)
            //////步骤一：先执行下面的
            /////*
            ////  通过Migration初始化数据库
            ////  add-migration InitialIdentityServerConfigurationDbMigration -c ConfigurationDbContext -o Data/Migrations/IdentityServer/ConfigurationDb 
            ////  add-migration InitialIdentityServerPersistedGrantDbMigration -c PersistedGrantDbContext -o Data/Migrations/IdentityServer/PersistedGrantDb
            //// */

            ////services.AddDbContext<ConfigurationDbContext>(opt => opt.UseSqlServer(connectionString
            ////    , b => b.MigrationsAssembly("Zhaoxi.AspNetCore31.AuthenticationCenterIds4")));

            ////services.AddDbContext<PersistedGrantDbContext>(opt => opt.UseSqlServer(connectionString
            ////    , b => b.MigrationsAssembly("Zhaoxi.AspNetCore31.AuthenticationCenterIds4")));

            //////步骤二(必须先单独执行步骤一，然后在单独执行步骤二)：生成Data/Migrations/IdentityServer/ConfigurationDb对应的文件后，在单独调用services.InitSeedData(connectionString)初始化数据库。
            ////var connectionString = this.Configuration.GetConnectionString("DefaultConnection");
            ////services.InitSeedData(connectionString);//初始原来的那些内存数据 
            //#endregion

            //var connectionString = this.Configuration.GetConnectionString("DefaultConnection");
            //services
            //    .AddIdentityServer()
            //    .AddDeveloperSigningCredential()
            //    .AddConfigurationStore(options =>
            //    {
            //        options.ConfigureDbContext = builder =>
            //        {
            //            builder.UseSqlServer(connectionString);
            //        };
            //    })
            //    .AddOperationalStore(options =>
            //    {
            //        options.ConfigureDbContext = builder =>
            //        {
            //            builder.UseSqlServer(connectionString);
            //        };
            //    })
            //   //.AddTestUsers(PasswordInitConfig.GetUsers());
            //   .AddResourceOwnerValidator<CustomResourceOwnerPasswordValidator>()
            //   .AddProfileService<CustomProfileService>();
            //services.AddTransient<IUserServiceTest, UserServiceTest>();
            #endregion

            #region 密码模式+EFCore
            var connectionString = this.Configuration.GetConnectionString("DefaultConnection");
            //services.InitSeedData(connectionString);//初始原来的那些内存数据 
            services
                .AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = builder =>
                    {
                        builder.UseSqlServer(connectionString);
                    };
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = builder =>
                    {
                        builder.UseSqlServer(connectionString);
                    };
                })
                .AddExtensionGrantValidator<CustomElevenGrantValidator>();
            services.AddTransient<IUserServiceTest, UserServiceTest>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            //访问wwwroot目录静态文件
            app.UseStaticFiles(
                new StaticFileOptions()
                {
                    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot"))
                });

            //启用cookie策略
            app.UseCookiePolicy();

            #region 添加IdentityServer中间件
            app.UseIdentityServer();//拦截部分请求
            #endregion

            app.UseRouting();

            app.UseAuthorization();

            //使用Mvc中间件
            //app.UseMvcWithDefaultRoute();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

    }
}
