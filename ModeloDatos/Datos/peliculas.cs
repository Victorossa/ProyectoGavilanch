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
        public string Titulo { get; set; }
        public bool EstaEnCartelera { get; set; }
        public string Genero { get; set; }
        public DateTime FechaProduccion { get; set; }


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
