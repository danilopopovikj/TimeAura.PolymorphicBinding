using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace TimeAura.PolymorphicBinding.JsonConverters
{
    public class FormCreationConverter : JsonConverter
    {
        public override bool CanWrite { get { return false; } }

        public Form Create(JObject jObject)
        {
            if (jObject == null) throw new ArgumentNullException("jObject");
            var paymentMethodType = GetFormType(jObject);

            if (paymentMethodType == FormType.T1)
            {
                return new T1Form();
            }
            else if (paymentMethodType == FormType.T2)
            {
                return new T2Form();
            }

            throw new ArgumentException($"Cannot convert JSON.");
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(Form).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader == null) throw new ArgumentNullException("Reader is null");
            if (serializer == null) throw new ArgumentNullException("Serializer is null");
            if (reader.TokenType == JsonToken.Null)
                return null;

            JObject jObject = JObject.Load(reader);
            var target = Create(jObject);
            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        private static FormType GetFormType(JObject jObject)
        {
            var paymentMethodType = jObject.GetValue("FormType", StringComparison.OrdinalIgnoreCase);
            return paymentMethodType.ToObject<FormType>();
        }
    }
}
