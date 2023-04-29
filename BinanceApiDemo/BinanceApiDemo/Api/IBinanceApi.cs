using System.Threading.Tasks;
using BinanceApiDemo.Data;
using Refit;

namespace BinanceApiDemo.Api
{
    public interface IBinanceApi
    {
        [Get("/api/v3/ticker/24hr")]
        Task<ApiResponse<Ticket[]>> Get24HTicketsAsync();
    }
}