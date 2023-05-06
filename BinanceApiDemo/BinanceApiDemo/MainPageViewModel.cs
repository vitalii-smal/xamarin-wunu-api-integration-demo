using System.Threading.Tasks;
using BinanceApiDemo.Data;
using BinanceApiDemo.Services;
using Xamarin.CommunityToolkit.ObjectModel;

namespace BinanceApiDemo
{
    public class MainPageViewModel : ObservableObject
    {
        private readonly IBinanceService _binanceService;

        private Ticket[] _tickets;
        private string _error;

        public MainPageViewModel(IBinanceService binanceService)
        {
            _binanceService = binanceService;

            Task.Run(InitAsync);
        }

        public Ticket[] Tickets
        {
            get => _tickets;
            set => SetProperty(ref _tickets, value);
        }

        public string Error
        {
            get => _error;
            set => SetProperty(ref _error, value);
        }

        public async Task InitAsync()
        {
            var ticketsResponse = await _binanceService.GetTicketsAsync();
            if (ticketsResponse.IsSuccessful)
            {
                Tickets = ticketsResponse.Data;
            }
            else
            {
                Error = ticketsResponse.Error;
            }
        }
    }
}