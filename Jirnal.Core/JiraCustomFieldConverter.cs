using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Tools.ExtensionMethods;

namespace Jirnal.Core
{
    public class JiraCustomFieldConverter<T> : JsonConverter<T> where T : class, ICustomFields, new()
    {
        public override void WriteJson(JsonWriter writer, T value, JsonSerializer serializer)
        { throw new NotImplementedException(); }
        

        public override T ReadJson(JsonReader reader, Type objectType, T existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            var item = hasExistingValue ? existingValue : new T();
            var jsonObject = JObject.Load(reader);

            foreach (var field in jsonObject.Properties().Where(prop => prop.Name.StartsWithCI("CustomField_")))
                item.CustomFields.Add(field.Name, field.Value);
            
            using (var jsonReader = CopyAndResetReader_(reader, jsonObject)) {
                serializer.Populate(jsonReader, item);
            }
            
            return item;
        }


        private JsonReader CopyAndResetReader_(JsonReader reader, JToken token)
        {
            var newReader = token.CreateReader();
            newReader.Culture = reader.Culture;
            newReader.DateFormatString = reader.DateFormatString;
            newReader.DateParseHandling = reader.DateParseHandling;
            newReader.DateTimeZoneHandling = reader.DateTimeZoneHandling;
            newReader.FloatParseHandling = reader.FloatParseHandling;
            newReader.MaxDepth = reader.MaxDepth;
            newReader.SupportMultipleContent = reader.SupportMultipleContent;
            return newReader;
        }
        
    }
}