using GraphQL;
using GraphQL.Http;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using MangaStore.DataAccess;
using MangaStore.Database.DbContexts;
using MangaStore.GraphQl;
using MangaStore.GraphQl.GraphTypes.Books;
using MangaStore.GraphQl.GraphTypes.Genres;
using MangaStore.GraphQl.GraphTypes.Moneys;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MangaStore
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<MangaStoreDbContext>();

            services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();

            services.AddSingleton<BookGraphType>();
            services.AddSingleton<BookInputGraphType>();

            services.AddSingleton<GenreGraphType>();

            services.AddSingleton<MoneyGraphType>();
            services.AddSingleton<MoneyInputGraphType>();

            services.AddSingleton<MangaStoreQuery>();
            services.AddSingleton<MangaStoreMutation>();

            // This way of injecting solves the scope conflict created by MangaStoreQuery and DbContext
            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new MangaStoreSchema (new FuncDependencyResolver(type => sp.GetService(type))));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, MangaStoreDbContext mangaStoreDbContext)
        {
            mangaStoreDbContext.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                mangaStoreDbContext.EnsureSeedData();
            }
            else
                app.UseHsts();

            app.UseHttpsRedirection();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions
            {
                Path = "/ui/playground"
            });

            app.UseMvc();

        }
    }
}
