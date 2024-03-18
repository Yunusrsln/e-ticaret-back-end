using Microsoft.OpenApi.Models;

namespace ETicaret.Extension
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "E-Commerce API", Version = "v1" });
                var securitySchema = new OpenApiSecurityScheme
                {
                    Description="Jwt Auth Bearer Scheme",
                    Name ="Authorization",
                    In=ParameterLocation.Header,
                    Type=SecuritySchemeType.Http,
                    Scheme="bearer",
                    Reference=new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id="Bearer"
                    }
                };
                c.AddSecurityDefinition("Baerer",securitySchema);
                var securityRequirement = new OpenApiSecurityRequirement
                {
                    {securitySchema,new[]{"Baerer"} }
                };
            });
            return services;
        }
         
        public static IApplicationBuilder UseSwaggerDocumantation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "E-Commerce API");
            });
            return app;
        }
            
    }
}
