using ModeloDatos.Datos.Validaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ModeloDatos.Datos
{
    public class peliculas : IValidatableObject
    {
        [Key]
        public int Pelicula_Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        public bool EstaEnCartelera { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Genero { get; set; }
        [Required(ErrorMessage = "{0} es Requerido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Produccion")]
        public Nullable<System.DateTime> FechaProduccion { get; set; }
        [DivisibleEntreAtribute(2, ErrorMessage = "El valor del codigo {0} no es un numero Par")]
        public int CodigoParPelicula { get; set; }
        public int valorBase { get; set; }
        public int valorMaxima { get; set; }
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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errores = new List<ValidationResult>();
            if ((valorBase * 4) < valorMaxima)
            {
                errores.Add(new ValidationResult("El monto de valor base no debe ser 4 veces superior que el valor base",
                   new string[] { "valorMaxima" }));
            }
            if (CodigoParPelicula == 10)
            {
                errores.Add(new ValidationResult("El codigo par no debe ser igual a 10",
                   new string[] { "CodigoParPelicula" }));
            }
            return errores;
        }
    }
}
