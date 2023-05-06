namespace BinanceApiDemo.Data
{
    public class Response<TData>
    {
        public bool IsSuccessful => Error == default;
        
        public string Error { get; private set; }
        
        public TData Data { get; private set; }

        public static Response<TData> Success(TData data)
        {
            return new Response<TData>
            {
                Data = data
            };
        }

        public static Response<TData> Fail(string error)
        {
            return new Response<TData>
            {
                Error = error
            };
        }
    }
}