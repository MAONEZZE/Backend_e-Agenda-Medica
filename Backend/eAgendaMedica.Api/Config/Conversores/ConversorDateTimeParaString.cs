using System.Text.Json.Serialization;
using System.Text.Json;

namespace eAgendaMedica.Api.Config.Conversores
{
    public class ConversorDateTimeParaString : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();

            var data = DateTime.Parse(value!);

            return data;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToShortDateString());
        }
    }
}
