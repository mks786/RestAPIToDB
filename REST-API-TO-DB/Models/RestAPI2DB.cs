using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace REST_API_TO_DB.Models
{
    public partial class RESTAPI2DB
    {
        [JsonProperty("ScheduleResult")]
        public ScheduleResult ScheduleResult { get; set; }
    }

    public partial class ScheduleResult
    {
        [JsonProperty("Schedules")]
        public Schedule[] Schedules { get; set; }
    }

    public partial class Schedule
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [JsonProperty("ContractTimeMinutes")]
        public long ContractTimeMinutes { get; set; }

        [JsonProperty("Date")]
        public Date Date { get; set; }

        [JsonProperty("IsFullDayAbsence")]
        public bool IsFullDayAbsence { get; set; }

        [Column(TypeName = "varchar(100)")]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("PersonId")]
        public Guid PersonId { get; set; }

        [JsonProperty("Projection")]
        //public Projection[] Projection { get; set; }
        public ICollection<Projection> Projection { get; set; }

    }

    public partial class Projection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [JsonProperty("Color")]
        public Color Color { get; set; }

        [JsonProperty("Description")]
        public Description Description { get; set; }

        [JsonProperty("Start")]
        public string Start { get; set; }

        [JsonProperty("minutes")]
        public long Minutes { get; set; }

        [ForeignKey("Schedule")]
        public int ScheduleId { get; set; }

        public Schedule Schedule { get; set; }
    }

    public partial class UserInfo
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public enum Date { Date14500512000000000 };

    public enum Color { Ff0000, Ffc080, Ffff00, The1E90Ff, The80Ff80 };

    public enum Description { Chat, Lunch, Phone, ShortBreak, SocialMedia };

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                DateConverter.Singleton,
                ColorConverter.Singleton,
                DescriptionConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class DateConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Date) || t == typeof(Date?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "/Date(1450051200000+0000)/")
            {
                return Date.Date14500512000000000;
            }
            throw new Exception("Cannot unmarshal type Date");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Date)untypedValue;
            if (value == Date.Date14500512000000000)
            {
                serializer.Serialize(writer, "/Date(1450051200000+0000)/");
                return;
            }
            throw new Exception("Cannot marshal type Date");
        }

        public static readonly DateConverter Singleton = new DateConverter();
    }

    internal class ColorConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Color) || t == typeof(Color?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "#1E90FF":
                    return Color.The1E90Ff;
                case "#80FF80":
                    return Color.The80Ff80;
                case "#FF0000":
                    return Color.Ff0000;
                case "#FFC080":
                    return Color.Ffc080;
                case "#FFFF00":
                    return Color.Ffff00;
            }
            throw new Exception("Cannot unmarshal type Color");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Color)untypedValue;
            switch (value)
            {
                case Color.The1E90Ff:
                    serializer.Serialize(writer, "#1E90FF");
                    return;
                case Color.The80Ff80:
                    serializer.Serialize(writer, "#80FF80");
                    return;
                case Color.Ff0000:
                    serializer.Serialize(writer, "#FF0000");
                    return;
                case Color.Ffc080:
                    serializer.Serialize(writer, "#FFC080");
                    return;
                case Color.Ffff00:
                    serializer.Serialize(writer, "#FFFF00");
                    return;
            }
            throw new Exception("Cannot marshal type Color");
        }

        public static readonly ColorConverter Singleton = new ColorConverter();
    }

    internal class DescriptionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Description) || t == typeof(Description?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Chat":
                    return Description.Chat;
                case "Lunch":
                    return Description.Lunch;
                case "Phone":
                    return Description.Phone;
                case "Short break":
                    return Description.ShortBreak;
                case "Social Media":
                    return Description.SocialMedia;
            }
            throw new Exception("Cannot unmarshal type Description");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Description)untypedValue;
            switch (value)
            {
                case Description.Chat:
                    serializer.Serialize(writer, "Chat");
                    return;
                case Description.Lunch:
                    serializer.Serialize(writer, "Lunch");
                    return;
                case Description.Phone:
                    serializer.Serialize(writer, "Phone");
                    return;
                case Description.ShortBreak:
                    serializer.Serialize(writer, "Short break");
                    return;
                case Description.SocialMedia:
                    serializer.Serialize(writer, "Social Media");
                    return;
            }
            throw new Exception("Cannot marshal type Description");
        }

        public static readonly DescriptionConverter Singleton = new DescriptionConverter();
    }
}
