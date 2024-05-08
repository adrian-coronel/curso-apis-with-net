using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace curso_apis_with_net.DBContext;

// Definimos un contexto de base de datos que hereda de DbContext
public class TareasContext : DbContext
{

    // Propiedades DbSet para definir las entidades
    // DbSet => Para consultar y guardar instancias. Permitiendo usar Query LINQ
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }


    public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

    // Aqui configuramos el modelo de datos
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Se crean 2 categorías de prueba para agregarla a la Categoria
        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), Nombre = "Actividades pendientes", Peso = 20 });
        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb402"), Nombre = "Actividades personales", Peso = 50 });


        // Configuramos la ENTIDAD CATEGORIA
        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categoria"); // Nombre de tabla
            categoria.HasKey(p => p.CategoriaId); // Definimos la KEY

            categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150); // Propiedad requerida y con 150 max caracteres

            categoria.Property(p => p.Descripcion).IsRequired(false);

            categoria.Property(p => p.Peso);

            categoria.HasData(categoriasInit);
        });

        List<Tarea> tareasInit = new List<Tarea>();

        tareasInit.Add(new Tarea() { TareaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb410"), CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), PrioridadTarea = Prioridad.Media, Titulo = "Pago de servicios publicos", FechaCreacion = DateTime.Now });
        tareasInit.Add(new Tarea() { TareaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb411"), CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb402"), PrioridadTarea = Prioridad.Baja, Titulo = "Terminar de ver pelicula en netflix", FechaCreacion = DateTime.Now });


        // Configuración del modelo para la entidad Tarea
        modelBuilder.Entity<Tarea>(tarea =>
        {
            tarea.ToTable("Tarea"); // Establece el nombre de la tabla en la base de datos
            tarea.HasKey(p => p.TareaId); // Establece la clave primaria

            // Configura la RELACION entre Tarea y Categoria
            tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId); 

            tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200); // Configura la propiedad Titulo como requerida y con una longitud máxima de 200 caracteres
            tarea.Property(p => p.Descripcion).IsRequired(false); // Configura la propiedad Descripcion como opcional
            tarea.Property(p => p.PrioridadTarea); // Configura la propiedad PrioridadTarea
            tarea.Property(p => p.FechaCreacion); // Configura la propiedad FechaCreacion

            tarea.Ignore(p => p.Resumen); // Ignora la propiedad Resumen

            tarea.HasData(tareasInit); // Agrega datos iniciales a la tabla Tarea
        });

    }

}