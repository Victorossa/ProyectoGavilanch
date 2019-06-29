using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatos.Datos
{
    public class Persona
    {
        [Key]
        public int Persona_Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Nacimiento { get; set; }
        public int Edad { get; set; }
        public virtual List<Direccion> Direcciones { get; set; }
    }
}
