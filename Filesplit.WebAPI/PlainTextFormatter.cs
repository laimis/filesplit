using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Filesplit.WebAPI
{
    internal class PlainTextFormatter : IInputFormatter
    {
        public bool CanRead(InputFormatterContext context)
        {
            return context.HttpContext.Request.ContentType == "text/plain";
        }

        public Task<InputFormatterResult> ReadAsync(InputFormatterContext context)
        {
            var taskCompletionSource = new TaskCompletionSource<InputFormatterResult>();
            try
            {
                using(var reader = new StreamReader(context.HttpContext.Request.Body))
                {
                    var r = InputFormatterResult.Success(reader.ReadToEnd());

                    taskCompletionSource.SetResult(r);
                }
            }
            catch (Exception e)
            {
                taskCompletionSource.SetException(e);
            }
            
            return taskCompletionSource.Task;
        }
    }
}