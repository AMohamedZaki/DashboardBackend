using Microsoft.AspNetCore.Http;

namespace Zanobia.Helper
{
    public class BaseResponse<T> where T : class
    {
        public BaseResponse()
        {
            StatusCode = StatusCodes.Status200OK;
            IsSuccess = true;
        }
        public T? Data { get; set; } = null;
        public int StatusCode { get; set; }
        public string ResponseMessage { get; set; }
        public bool IsSuccess { get; set; }
        public int TotalRecords { get; set; }
    }
}
