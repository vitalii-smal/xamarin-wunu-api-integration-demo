using System.Threading.Tasks;
using BinanceApiDemo.Data;

namespace BinanceApiDemo.Services
{
    public interface IBinanceService
    {
        Task<Response<Ticket[]>> GetTicketsAsync();
    }
}