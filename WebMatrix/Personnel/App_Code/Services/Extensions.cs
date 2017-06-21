using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Json;
using ProSoft.Personnel;
using ProSoft.Personnel.Data;
using System.Collections;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Summary description for Extensions
/// </summary>
public static class Extensions
{
    public static JsonValue ToJson(this IEnumerable objects)
    {
        var array = new JsonArray();

        foreach (var @object in objects)
            array.Add(@object.ToJson());

        return array;
    }

    public static JsonValue ToJson(this object @object)
    {
        dynamic json = new JsonObject();

        var type = @object.GetType(); //.BaseType;

        foreach (var property in type.GetProperties())
        {
            var propertyType = property.PropertyType;
            if (propertyType.IsValueType || propertyType == typeof(string))
                json[property.Name] = property.GetValue(@object, null);
            else if (Attribute.IsDefined(propertyType, typeof(ComplexTypeAttribute)))
                json[property.Name] = property.GetValue(@object, null).ToJson();
        }
        return json;
    }
}