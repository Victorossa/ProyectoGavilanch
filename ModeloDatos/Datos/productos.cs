namespace ModeloDatos.Datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class productos
    {
        private BD_ProyectoGavilanchContext db = new BD_ProyectoGavilanchContext();

        public productos()
        {
            almacenes = new HashSet<almacenes>();
        }

        [Key]
        public int Producto_Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Nombre { get; set; }

        [StringLength(500)]
        public string Descripcion { get; set; }

        [StringLength(500)]
        public string Imagen { get; set; }

        public decimal? Precio { get; set; }

        public int? GrupoProducto_Id { get; set; }

        public int? Marca_Id { get; set; }

        public virtual gruposProductos gruposProductos { get; set; }

        public virtual marcas marcas { get; set; }

        public virtual ICollection<almacenes> almacenes { get; set; }

        public List<productos> Listar()
        {
            var productos = new List<productos>();
            try
            {
                using (var context = new BD_ProyectoGavilanchContext { })
                {
                    productos = context.productos.ToList();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return productos;
        }
    }
}
