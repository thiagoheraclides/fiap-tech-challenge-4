using log4net;
using System.Text;

namespace Br.Com.Fiap.Api.Resources.Middleware
{
    public class HttpLoggingMiddleware(RequestDelegate next, ILog logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILog _logger = logger;

        public async Task InvokeAsync(HttpContext context)
        {
            var originalResponseBody = context.Response.Body;

            context.Request.EnableBuffering();

            using (var reader = new StreamReader(
                context.Request.Body,
                encoding: Encoding.UTF8,
                detectEncodingFromByteOrderMarks: false,
                bufferSize: context.Request.ContentLength > 0 ? Convert.ToInt32(context.Request.ContentLength) : 1,                
                leaveOpen: true))
            {
                var body = await reader.ReadToEndAsync();                
                _logger.Info($" {context.Request.Path} - { context.Request.Method } { body.Replace("\n", "").Replace("\r", "") } ");

                context.Request.Body.Position = 0;
            }

            await using var tempResponseBody = new MemoryStream();
            context.Response.Body = tempResponseBody;

            await _next(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var responseBody = await new StreamReader(context.Response.Body).ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);

            _logger.Info($" { context.Response.StatusCode } - { responseBody.Replace("\n", "").Replace("\r", "") }");

            await tempResponseBody.CopyToAsync(originalResponseBody);

        }        
    }
}
