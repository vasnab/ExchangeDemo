using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ExchangeDemoApi.Models
{
    public partial class ExchangeRates
    {
        [JsonProperty("rates")]
        public Dictionary<string, double> Rates { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }
    }

    public partial class ExchangeRates
    {
        public static ExchangeRates FromJson(string json) => JsonConvert.DeserializeObject<ExchangeRates>(json, ExchangeDemoApi.Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this ExchangeRates self) => JsonConvert.SerializeObject(self, ExchangeDemoApi.Models.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
