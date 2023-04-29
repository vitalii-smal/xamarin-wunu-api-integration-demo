using System.Text.Json.Serialization;

namespace BinanceApiDemo.Data
{
    public class Ticket
    {
        [JsonPropertyName("symbol")]
        public string Name { get; set; }

        public string PriceChangePercent { get; set; }
        
        public string LastPrice { get; set; }
    }
}