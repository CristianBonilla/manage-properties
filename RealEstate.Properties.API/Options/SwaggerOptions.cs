using Microsoft.OpenApi.Models;

namespace RealEstate.Properties.API.Options
{
    class SwaggerOptions
    {
        public string JsonRoute { get; set; }
        public string Description { get; set; }
        public string UIEndpoint { get; set; }
        public OpenApiContact Contact { get; set; }
    }
}
