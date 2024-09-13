namespace DigiMenu.Razor.Infrastructure
{
    public class ApiResult
    {
        public bool IsSuccess { get; set; }
        public MetaData MetaData { get; set; }
    }

    public class ApiResult<TData>
    {
        public bool IsSuccess { get; set; }
        public TData? Data { get; set; }
        public MetaData MetaData { get; set; }
    }

    public class MetaData
    {
        public string Message { get; set; }
        public ResponseStatusCode StatusCode { get; set; }
    }

    public enum ResponseStatusCode
    {
        Success = 1,
        NotFound = 2,
        BadRequest = 3,
        LogicError = 4,
        AccessDenied = 5,
        UnAuthorized = 6,
        ServerError = 7

    }
}
