// Crea un constructor de aplicaciones web con la configuraci�n inicial
var builder = WebApplication.CreateBuilder(args);

// Agrega los servicios necesarios al contenedor de inyecci�n de dependencias
builder.Services.AddControllers(); // Agrega el servicio para controladores MVC
builder.Services.AddEndpointsApiExplorer(); // Agrega el servicio para la exploraci�n de puntos finales de la API
builder.Services.AddSwaggerGen(); // Agrega el servicio para la generaci�n de Swagger/OpenAPI

// Construye la aplicaci�n con la configuraci�n proporcionada
var app = builder.Build();

// Configura el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment()) // Verifica si la aplicaci�n est� en modo de desarrollo
{
    app.UseSwagger(); // Habilita Swagger/OpenAPI para la documentaci�n de la API
    app.UseSwaggerUI(); // Habilita Swagger UI para interactuar con la documentaci�n de la API
}

app.UseHttpsRedirection(); // Redirige el tr�fico HTTP a HTTPS
app.UseAuthorization(); // Habilita la autorizaci�n en la aplicaci�n
app.MapControllers(); // Mapea los controladores para procesar las solicitudes

// Ejecuta la aplicaci�n
app.Run();

