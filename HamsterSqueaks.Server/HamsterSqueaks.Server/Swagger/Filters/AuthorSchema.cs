using HamsterSqueaks.Server.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HamsterSqueaks.Server.Swagger.Filters
{
    public class AuthorSchema : ISchemaFilter
    {
        public void Apply(Schema model, SchemaFilterContext context)
        {
            var type = context.SystemType.GetTypeInfo();

            if (type == typeof(Author))
            {
                model.Example = new
                {
                    PenName = "MartinJH"
                };
            }
        }
    }
}
