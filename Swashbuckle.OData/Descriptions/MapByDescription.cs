using System.Diagnostics.Contracts;
using System.Linq;
using System.Web.Http.Controllers;
using Swashbuckle.Swagger;

namespace Swashbuckle.OData.Descriptions
{
    internal class MapByDescription : IParameterMapper
    {
        public HttpParameterDescriptor Map(Parameter swaggerParameter, int parameterIndex, HttpActionDescriptor actionDescriptor)
        {
            // Maybe the parameter is a key parameter, e.g., where Id in the URI path maps to a parameter named 'key'
            if (swaggerParameter.description != null && swaggerParameter.description.StartsWith("key:"))
            {
                var parameterDescriptor = actionDescriptor.GetParameters()?.SingleOrDefault(descriptor => descriptor.ParameterName == "key");
                if (parameterDescriptor != null && !parameterDescriptor.IsODataLibraryType())
                {
                    var httpControllerDescriptor = actionDescriptor.ControllerDescriptor;
                    Contract.Assume(httpControllerDescriptor != null);
                    return new ODataParameterDescriptor(swaggerParameter.name, parameterDescriptor.ParameterType, parameterDescriptor.IsOptional, parameterDescriptor)
                    {
                        Configuration = httpControllerDescriptor.Configuration,
                        ActionDescriptor = actionDescriptor,
                        ParameterBinderAttribute = parameterDescriptor.ParameterBinderAttribute
                    };
                }
            }
            return null;
        }
    }
}