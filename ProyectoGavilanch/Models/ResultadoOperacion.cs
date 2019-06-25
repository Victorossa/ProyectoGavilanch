using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ProyectoGavilanch.Models
{
    public enum ResultadoOperacion
    {
        Aprobado = 1,
        Rechazado = 2,
        Pendiente = 7,
        [Description("Pendiente Aprobación")]
        PendienteAprobacion = 11
    }
}