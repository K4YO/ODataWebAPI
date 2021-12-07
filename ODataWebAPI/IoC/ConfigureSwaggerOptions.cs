using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ODataWebAPI.IoC
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
       
        public void Configure(SwaggerGenOptions options)
        {           
                options.SwaggerDoc("v1",
                    new OpenApiInfo()
                    {
                        Title = $"ASP.NET Core OData RESTful API V1",
                        Description = "ASP.NET Core OData RESTful API",
                        Version = "v1",
                    });
        }
    }
}
