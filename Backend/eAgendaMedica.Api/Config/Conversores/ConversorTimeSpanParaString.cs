using System.Text.Json;
using System.Text.Json.Serialization;

namespace eAgendaMedica.Api.Config.Conversores
{
    public class ConversorTimeSpanParaString : JsonConverter<TimeSpan>
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
