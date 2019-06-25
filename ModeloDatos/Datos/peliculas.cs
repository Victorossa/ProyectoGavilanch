using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatos.Datos
{
    public class peliculas
    {
        [Key]
        public int Pelicula_Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        public bool EstaEnCartelera { get; set; }
        [Required]
        public string Genero { get; set; }
        [Required(ErrorMessage = "{0} es Requerido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Produccion")]
        public Nullable<System.DateTime> FechaProduccion { get; set; }
        public int CodigoParPelicula { get; set; }
        public List<peliculas> ListarPeliculas()
        {
            var peliculas = new List<peliculas>();
            try
            {
                using (var context = new BD_ProyectoGavilanchContext { })
                {
                    peliculas = context.Peliculas.ToList();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return peliculas;
        }
    }
}
