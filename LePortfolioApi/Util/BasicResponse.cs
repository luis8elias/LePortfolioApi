namespace LePortfolioApi.Util
{

    public class BasicResponse<T> : BasicResponse
    {
        public T? Model { get; set; }

    }

    public class BasicResponse
    {
        public string? Message { get; set; }
        public bool Success { get; set; }
    }
}
