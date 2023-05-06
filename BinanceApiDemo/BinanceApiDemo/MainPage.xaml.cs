using BinanceApiDemo.Factories;
using BinanceApiDemo.Services;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace BinanceApiDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            On<iOS>().SetUseSafeArea(true);

            var binanceApi = BinanceApiFactory.Create();
            var binanceService = new BinanceService(binanceApi);
            BindingContext = new MainPageViewModel(binanceService);
        }
    }
}