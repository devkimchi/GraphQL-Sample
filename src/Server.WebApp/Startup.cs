using System.Reflection;
using System.Threading.Tasks;

using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.GraphiQL;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using PostsQL.Schemas;
using PostsQL.Services;

namespace Server.WebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(o => o.AllowSynchronousIO = true);

            services.AddSingleton<IAuthorService, AuthorService>();
            services.AddSingleton<IPostService, PostService>();
            services.AddSingleton<AuthorType>();
            services.AddSingleton<PostType>();
            services.AddSingleton<PostStatusEnum>();
            services.AddSingleton<PostsQuery>();
            services.AddSingleton<PostsSchema>();
            services.AddSingleton<IDependencyResolver>(p => new FuncDependencyResolver(type => p.GetRequiredService(type)));

            services.AddGraphQL()
                    .AddWebSockets()
                    .AddGraphTypes(Assembly.GetAssembly(typeof(PostsSchema)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await Task.Run(() => context.Response.Redirect("/ui/graphql", permanent: true));
                });
            });

            app.UseWebSockets();
            app.UseGraphQLWebSockets<PostsSchema>();
            app.UseGraphQL<PostsSchema>();
            app.UseGraphiQLServer(new GraphiQLOptions() { GraphiQLPath = "/ui/graphql", GraphQLEndPoint = "/graphql" });
        }
    }
}
