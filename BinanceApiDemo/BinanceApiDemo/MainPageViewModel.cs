using System.Threading.Tasks;
using BinanceApiDemo.Api;
using BinanceApiDemo.Data;
using Refit;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms.Internals;

namespace BinanceApiDemo
{
    public class MainPageViewModel : ObservableObject
    {
        private const string BinanceApiUrl = "https://data.binance.com";
        
        private readonly IBinanceApi _binanceApi;

        private Ticket[] _tickets;

        public MainPageViewModel()
        {
            _binanceApi = RestService.For<IBinanceApi>(BinanceApiUrl);

            Task.Run(InitAsync);
        }

        public Ticket[] Tickets
        {
            get => _tickets;
            set => SetProperty(ref _tickets, value);
        }

        private async Task InitAsync()
        {
            var ticketsResponse = await _binanceApi.Get24HTicketsAsync();
            if (ticketsResponse.IsSuccessStatusCode)
            {
                Tickets = ticketsResponse.Content;
            }
            else
            {
                // ToDo error message
            }
        }
    }
}