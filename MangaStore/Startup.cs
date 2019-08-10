using GraphiQl;
using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using MangaStore.DataAccess;
using MangaStore.Database.DbContexts;
using MangaStore.Queries;
using MangaStore.Schemas;
using MangaStore.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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

            services.AddSingleton<MangaStoreDbContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();

            services.AddSingleton<BookType>();
            services.AddSingleton<CategoryType>();
            services.AddSingleton<BookQuery>();
            services.AddSingleton<CategoryQuery>();

            services.AddSingleton<ISchema, MangaStoreSchema>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, MangaStoreDbContext mangaStoreDbContext)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseHttpsRedirection();
            app.UseGraphiQl();
            app.UseMvc();

            mangaStoreDbContext.EnsureSeedData();
        }
    }
}
