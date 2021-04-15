using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebApp
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var apiVersionDescription in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(
                    apiVersionDescription.GroupName,
                    new OpenApiInfo()
                    {
                        Title = $"API{apiVersionDescription.ApiVersion}",
                        Version = apiVersionDescription.ApiVersion.ToString()
                    });
            }
        }
    }
}