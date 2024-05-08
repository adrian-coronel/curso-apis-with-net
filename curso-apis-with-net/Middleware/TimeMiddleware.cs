namespace curso_apis_with_net.Middleware
{
    public class TimeMiddleware
    {
        private readonly RequestDelegate _next;

        public TimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context); // Invoca el siguiente middleware en la canalización

            // Esto se ejecuta se ejecutara después de que se haya llegado al controlador pero antes de enviar la respuesta
            if (context.Request.Query.Any(x => x.Key == "time"))
            {
                await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());

            }
        }
    }

    // Define una clase estática para extender la funcionalidad de IApplicationBuilder
    public static class TimeMiddlewareExtensions
    {
        // Recibe el IApplicationBuilder y lo retorna con el MIddleware implementado
        public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
        {
            // Retorna el resultado de agregar el middleware de tiempo a la canalización de solicitud
            return builder.UseMiddleware<TimeMiddleware>();
        }
    }


}