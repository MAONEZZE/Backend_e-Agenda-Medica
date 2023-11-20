using System.Text.Json.Serialization;
using System.Text.Json;

namespace eAgendaMedica.Api.Config
{
    public class ConversorDateTimeParaString : JsonConverter<TimeSpan>
    {
        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();

            var data = TimeSpan.Parse(value!);

            return data;
        }

        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
