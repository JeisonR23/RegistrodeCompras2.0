using Microsoft.EntityFrameworkCore;

public class Contexto : DbContext
{
    public DbSet<Categorias> Categorias { get; set; }
    public DbSet<Productos> Productos { get; set; }
    public DbSet<Compras> Compras { get; set; }
  

    public Contexto(DbContextOptions<Contexto> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorias>().HasData(
          new Categorias() { CategoriaId = 1, Descripcion = "Alimentos" },
          new Categorias() { CategoriaId = 2, Descripcion = "Abarrotes" }
        );

       


        modelBuilder.Entity<Productos>().HasData(

            new Productos
            {
                ProductoId = 1,
        
                Descripcion = "Huevos",
                Costo = 5,
                Precio = 7,
                CategoriaId = 1,
                Existencia = 0
            },
            new Productos
            {
                ProductoId = 2,
                Descripcion = "Cebolla",
                Costo = 50,
                Precio = 85,
                CategoriaId = 1,
                Existencia = 0
            }
            );
    }
}