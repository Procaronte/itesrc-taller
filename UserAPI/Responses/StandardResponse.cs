using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Net;

namespace UserAPI.Responses
{
    public class StandardResponse<T> where T : class
    {
        public StandardResponse(HttpStatusCode statusCode, T data, string? message = "")
        {
            StatusCode = (int)statusCode;
            Data = data;
            Message = message;
        }
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public T Data { get; set; }
    }
}
