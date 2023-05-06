using System;
using System.Threading.Tasks;
using BinanceApiDemo.Api;
using BinanceApiDemo.Data;
using Refit;

namespace BinanceApiDemo.Services
{
    public class BinanceService : IBinanceService
    {
        private readonly IBinanceApi _binanceApi;

        public BinanceService(IBinanceApi binanceApi)
        {
            _binanceApi = binanceApi;
        }
        
        public async Task<Response<Ticket[]>> GetTicketsAsync()
        {
            try
            {
                var ticketsResponse = await _binanceApi.Get24HTicketsAsync();
                if (ticketsResponse.IsSuccessStatusCode)
                {
                    return Response<Ticket[]>.Success(ticketsResponse.Content);
                }

                return Response<Ticket[]>.Fail("failed to get tickets");
            }
            catch (ApiException refitException)
            {
                // DEMO
                return Response<Ticket[]>.Fail(refitException.Message);
            }
            catch (Exception exception)
            {
                return Response<Ticket[]>.Fail(exception.Message);
            }
        }
    }
}