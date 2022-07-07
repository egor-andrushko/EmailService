using System.Text.Json.Serialization;

namespace EmailServiceApi.Models.CoinRanking
{
    public class Coin
    {
        public string Uuid { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string IconUrl { get; set; }
        public string WebsiteUrl { get; set; }

        [JsonPropertyName("24hVolume")]
        public string Volume24h { get; set; }
        public string MarketCap { get; set; }
        public string Price { get; set; }
        public string BtcPrice { get; set; }
        public string Change { get; set; }
        public int Rank { get; set; }
        public int NumberOfMarkets { get; set; }
        public int NumberOfExchanges { get; set; }
        public string CoinrankingUrl { get; set; }
    }
}
