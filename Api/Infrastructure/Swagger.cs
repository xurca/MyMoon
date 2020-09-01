using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace MyMoon.Api.Infrastructure
{
    public class AddRequiredHeaderParameter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<OpenApiParameter>();
            }
        }
    }

    public class LowercaseDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var openAPiPaths = new OpenApiPaths();

            foreach (var item in swaggerDoc.Paths)
            {
                var key = item.Key.ToLower();

                openAPiPaths.Add(key, item.Value);
            }

            swaggerDoc.Paths = openAPiPaths;
        }
    }
}
