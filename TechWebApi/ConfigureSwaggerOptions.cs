using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Security.Cryptography.Xml;

namespace TechWebApi
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {            
            foreach (var desc in _provider.ApiVersionDescriptions)
            {
                var apiVersion = desc.ApiVersion.ToString();
                options.SwaggerDoc(desc.GroupName,
                    new OpenApiInfo
                    {
                        Version = apiVersion,
                        Title = $"Tech API {apiVersion}",
                        Description = "A simp. example ASP NET CORE Web API. \r\n Perfect architecture Azim rulit!!!",
                        TermsOfService = new Uri("https://www.instagram.com/abdvazm?igsh=MXBkNTN2cW5yNjd2bQ=="),
                        Contact = new OpenApiContact
                        {
                            Name = "Azim Abdyev",
                            Email = "abdyev741@gmial.com",
                            Url = new Uri("https://t.me/+996558161565")
                        },
                        License = new OpenApiLicense
                        {
                            Name = "Azim Abdyev",
                            Url = new Uri("https://wa.me/+996558161565")
                        }
                    });

                //options.AddSecurityDefinition($"AuthToken {apiVersion}",
                //    new OpenApiSecurityScheme
                //    {
                //        In = ParameterLocation.Header,
                //        Type = SecuritySchemeType.Http,
                //        BearerFormat = "JWT",
                //        Scheme = "bearer",
                //        Name = "Authorization",
                //        Description = "Authorization token"
                //    });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = $"AuthToken {apiVersion}"
                        }
                    },
                    new string[]{}
                }
                });

                options.CustomOperationIds(apiDesc =>
                    apiDesc.TryGetMethodInfo(out MethodInfo methodInfo)
                        ? methodInfo.Name
                        : null);
            }
        }
    }
}
