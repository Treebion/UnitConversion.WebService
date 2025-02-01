using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Xml.Linq;

namespace UnitConversion.WebService.Examples;

public class XmlEnumDescriptionsSchemaFilter : ISchemaFilter
{
    private readonly XDocument _xmlDoc;

    public XmlEnumDescriptionsSchemaFilter(string xmlPath)
    {
        if (System.IO.File.Exists(xmlPath))
        {
            _xmlDoc = XDocument.Load(xmlPath);
        }
    }

    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (_xmlDoc == null || !context.Type.IsEnum)
            return;

        var enumType = context.Type;
        var members = _xmlDoc.Descendants("member")
            .Where(m => m.Attribute("name")?.Value.StartsWith($"F:{enumType.FullName}") == true)
            .ToDictionary(
                m => m.Attribute("name").Value.Split('.').Last(),
                m => m.Element("summary")?.Value.Trim()
            );

        if (members.Count > 0)
        {
            schema.Enum.Clear();
            schema.Description = "**Available Values:**";

            foreach (var field in Enum.GetNames(enumType))
            {
                var description = members.TryGetValue(field, out var desc) ? desc : field;

                // Add each value to the description instead of cluttering the enum list
                schema.Description += $"\n- `{field}` - {description}\n";

                // Show only the enum name in the dropdown (cleaner)
                schema.Enum.Add(new OpenApiString(field));
            }
        }
    }
}
