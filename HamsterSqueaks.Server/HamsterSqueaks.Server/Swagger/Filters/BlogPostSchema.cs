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
    public class BlogPostSchema : ISchemaFilter
    {
        public void Apply(Schema model, SchemaFilterContext context)
        {
            var type = context.SystemType.GetTypeInfo();

            if (type == typeof(BlogPost))
            {
                model.Example = new
                {
                    Title = "Why HamsterSqueaks?",
                    TitlePictureUrl = "www.hamstersqueaks.com/pictures/hamster.jpg",
                    Content = "Because hamster was my nickname",
                    EstimatedReadTime = new TimeSpan(0, 5, 30),
                    Published = new DateTime(2017, 09, 12),
                    Updated = new DateTime(2017, 09, 15),
                    UrlSlug = "why-hamstersqueaks",
                    AuthorId = 3
                };
            }
        }
    }
}
