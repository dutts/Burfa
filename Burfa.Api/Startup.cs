using System;
using Autofac;
using Burfa.Api.GameSession;
using Burfa.Bots;
using Burfa.Common.Board;
using Burfa.Common.Engine;
using Burfa.Common.Engine.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Burfa.Api
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
            services.AddMvc();

            // Adds a default in-memory implementation of IDistributedCache.
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.Cookie.Name = ".Burfa.Session";
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<GameSessions>().As<IGameSessions>().SingleInstance();
            builder.RegisterType<Rules>().As<IGameRules>().SingleInstance();
            builder.RegisterType<Game>().As<IGame>().SingleInstance();
            builder.RegisterType<Board>().As<IGameBoard>().SingleInstance();
            builder.RegisterType<RandomBot>().As<IBurfaBot>().SingleInstance().WithParameter("Player", Player.White);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSession();
            app.UseMvcWithDefaultRoute();
        }
    }
}
