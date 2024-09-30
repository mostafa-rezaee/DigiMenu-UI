using System.Net;

namespace DigiMenu.Razor.Models
{
    public class ApiResult
    {
        public bool IsSuccess { get; set; }
        public MetaData MetaData { get; set; }
        public bool IsReload { get; set; } = false;
        public static ApiResult Error(string message, bool isReload = false)
        {
            return new ApiResult()
            {
                IsSuccess = false,
                IsReload = isReload,
                MetaData = new MetaData()
                {
                    StatusCode = ResponseStatusCode.ServerError,
                    Message = message
                }
            };
        }
        public static ApiResult Error()
        {
            return new ApiResult()
            {
                IsSuccess = false,
                MetaData = new MetaData()
                {
                    StatusCode = ResponseStatusCode.ServerError,
                    Message = "عملیات ناموفق"
                }
            };
        }
        public static ApiResult Success(string message, bool isReload = false)
        {
            return new ApiResult()
            {
                IsSuccess = true,
                IsReload = isReload,
                MetaData = new MetaData()
                {
                    StatusCode = ResponseStatusCode.Success,
                    Message = message
                }
            };
        }
        public static ApiResult Success()
        {
            return new ApiResult()
            {
                IsSuccess = true,
                MetaData = new MetaData()
                {
                    StatusCode = ResponseStatusCode.Success,
                    Message = "عملیات با موفقیت انجام شد"
                }
            };
        }
    }

    public class ApiResult<TData>
    {
        public bool IsSuccess { get; set; }
        public TData? Data { get; set; }
        public MetaData MetaData { get; set; }
        public static ApiResult<TData> Success(TData data)
        {
            return new ApiResult<TData>()
            {
                IsSuccess = true,
                Data = data,
                MetaData = new MetaData()
                {
                    StatusCode = ResponseStatusCode.Success,
                    Message = "عملیات با موفقیت انجام شد"
                }
            };

        }
        public static ApiResult<TData> Error()
        {
            return new ApiResult<TData>()
            {
                IsSuccess = true,
                Data = default(TData),
                MetaData = new MetaData()
                {
                    StatusCode = ResponseStatusCode.LogicError,
                    Message = "عملیات ناموفق"
                }
            };
        }
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
