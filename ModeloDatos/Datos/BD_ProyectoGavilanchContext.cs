namespace ModeloDatos.Datos
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BD_ProyectoGavilanchContext : DbContext
    {
        public BD_ProyectoGavilanchContext()
            : base("name=BD_ProyectoGavilanchContext")
        {
        }

        public virtual DbSet<almacenes> almacenes { get; set; }
        public virtual DbSet<gruposProductos> gruposProductos { get; set; }
        public virtual DbSet<marcas> marcas { get; set; }
        public virtual DbSet<productos> productos { get; set; }
        public virtual DbSet<peliculas> Peliculas { get; set; }
        //public virtual DbSet<Persona> Personas { get; set; }
        //public virtual DbSet<Direccion> Direccions { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<almacenes>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<almacenes>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<almacenes>()
                .HasMany(e => e.productos)
                .WithMany(e => e.almacenes)
                .Map(m => m.ToTable("ProductoAlmacen").MapLeftKey("Almacen_Id").MapRightKey("Producto_Id"));

            modelBuilder.Entity<gruposProductos>()
                .Property(e => e.Nombre_Grupo)
                .IsUnicode(false);

            modelBuilder.Entity<marcas>()
                .Property(e => e.NombreMarca)
                .IsUnicode(false);

            modelBuilder.Entity<productos>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<productos>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<productos>()
                .Property(e => e.Imagen)
                .IsUnicode(false);

            modelBuilder.Entity<productos>()
                .Property(e => e.Precio)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Direccion>().HasRequired(e => e.Persona);

        }

        public System.Data.Entity.DbSet<ModeloDatos.Datos.Direccion> Direccions { get; set; }

        public System.Data.Entity.DbSet<ModeloDatos.Datos.Persona> Personas { get; set; }
    }
}
