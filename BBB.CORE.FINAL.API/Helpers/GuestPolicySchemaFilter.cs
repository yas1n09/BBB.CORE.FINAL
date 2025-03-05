using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BBB.CORE.FINAL.API.Helpers
{
    public class GuestPolicySchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.ParameterInfo?.Name == "guestPolicy") // Sadece guestPolicy için uygula
            {
                schema.Enum = new List<IOpenApiAny>
            {
                new OpenApiString("ALWAYS_ACCEPT"),
                new OpenApiString("ALWAYS_DENY"),
                new OpenApiString("ASK_MODERATOR")
            };
            }
        }
    }
}
