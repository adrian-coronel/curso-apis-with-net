// Crea un constructor de aplicaciones web con la configuración inicial
var builder = WebApplication.CreateBuilder(args);

// Agrega los servicios necesarios al contenedor de inyección de dependencias
builder.Services.AddControllers(); // Agrega el servicio para controladores MVC
builder.Services.AddEndpointsApiExplorer(); // Agrega el servicio para la exploración de puntos finales de la API
builder.Services.AddSwaggerGen(); // Agrega el servicio para la generación de Swagger/OpenAPI

// Construye la aplicación con la configuración proporcionada
var app = builder.Build();

// Configura el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment()) // Verifica si la aplicación está en modo de desarrollo
{
    app.UseSwagger(); // Habilita Swagger/OpenAPI para la documentación de la API
    app.UseSwaggerUI(); // Habilita Swagger UI para interactuar con la documentación de la API
}

app.UseHttpsRedirection(); // Redirige el tráfico HTTP a HTTPS
app.UseAuthorization(); // Habilita la autorización en la aplicación
app.MapControllers(); // Mapea los controladores para procesar las solicitudes

// Ejecuta la aplicación
app.Run();

