using Gateway.AddressInfo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using Gateway.StudentInfo;
using Graphql.API.GraphQL;
using Graphql.API.Types;

namespace Graphql.API
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Graphql.API", Version = "v1" });
            });

            services.AddHttpClient<IAddressServiceClient, AddressServiceClient>(client =>
            {
                client.BaseAddress = new Uri("http://address.api");
            });
            services.AddHttpClient<IStudentServiceClient, StudentServiceClient>(client =>
            {
                client.BaseAddress = new Uri("http://student.api");
            });

            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddType<StudentDtoType>()
                .AddType<AddressDtoType>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
