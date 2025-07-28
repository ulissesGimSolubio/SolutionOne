using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Ecomerce.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // Registrar a exceção
                Console.WriteLine($"Erro: {ex}");

                // Configurar o código de status da resposta
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                // Construir a resposta JSON
                var response = new
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Ocorreu um erro interno. Por favor, tente novamente mais tarde."
                };

                // Serializar a resposta e enviá-la de volta ao cliente
                var jsonResponse = JsonConvert.SerializeObject(response);
                await context.Response.WriteAsync(jsonResponse);
            }
        }
    }
}
