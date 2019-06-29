using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatos.Datos
{
    public class Direccion
    {
        [Key]
        public int Direccion_Id { get; set; }
        public string ReferenciaDireccion { get; set; }
        public virtual Persona Persona { get; set; }
    }
}
