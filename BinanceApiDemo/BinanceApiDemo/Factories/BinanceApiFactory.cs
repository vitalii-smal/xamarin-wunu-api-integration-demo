using BinanceApiDemo.Api;
using Refit;

namespace BinanceApiDemo.Factories
{
    public static class BinanceApiFactory
    {
        private const string BinanceApiUrl = "https://data.binance.com";
        
        public static IBinanceApi Create()
        {
            return RestService.For<IBinanceApi>(BinanceApiUrl);
        }
    }
}