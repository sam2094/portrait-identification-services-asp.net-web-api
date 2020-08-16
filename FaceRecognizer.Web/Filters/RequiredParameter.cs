using Swashbuckle.Swagger;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Description;

namespace FaceRecognizer.Web.Filters
{
    /// <summary>
    /// The filter that helps to show required header parameters in swagger ui
    /// </summary>
    internal class RequiredParameter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            IEnumerable<Auth> attrs = apiDescription.GetControllerAndActionAttributes<Auth>();
            operation.parameters = operation.parameters ?? new List<Parameter>();

            attrs.ForEach(attrItem =>
            {
                if (attrItem.GetType() == typeof(Auth))
                {
                    operation.parameters.Add(new Parameter
                    {
                        name = "token",
                        @in = "header",
                        type = "string",
                        required = true
                    });
                }
            });
        }
    }
}
