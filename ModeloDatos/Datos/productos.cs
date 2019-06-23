namespace ModeloDatos.Datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class productos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<almacenes> almacenes { get; set; }
    }
}
