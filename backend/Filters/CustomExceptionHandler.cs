using backend.Exceptions;
using backend.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace backend.Filters
{
    public class CustomExceptionHandler : IAsyncExceptionFilter
    {
        private readonly JsonSerializerSettings serializerSettings = new()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
        public Task OnExceptionAsync(ExceptionContext context)
        {
            if (context.ExceptionHandled == false)
            {
                R r = new();
                // check if is our defined exception
                if (context.Exception is CustomException customException)
                {
                    r.Message = customException.CodeAndMsg.GetExcpetionMessage();
                    r.Code = customException.CodeAndMsg.GetExcpetionCode();
                }
                else
                {
                    r.Message = "service error";
                    r.Code = StatusCodes.Status500InternalServerError;
                    Console.WriteLine(context.Exception);
                }
                context.Result = new ContentResult
                {
                    StatusCode = StatusCodes.Status200OK,
                    ContentType = "application/json;charset=utf-8",
                    Content = JsonConvert.SerializeObject(r, Formatting.None, serializerSettings)
                };
            }
            context.ExceptionHandled = true;
            return Task.CompletedTask;
        }
    }
}