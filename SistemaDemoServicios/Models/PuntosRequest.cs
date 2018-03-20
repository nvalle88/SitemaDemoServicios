using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDemoServicios.Models
{
  public  class PuntosRequest
    {

            public double lat { get; set; }
            public double lng { get; set; }
            public DateTime? Fecha { get; set; }
            public string NombreUsuario { get; set; }
            public string Telefono { get; set; }
            public string Ruc { get; set; }
            public string Direccion { get; set; }
            public string PersonaContacto { get; set; }
            public string Tipo { get; set; }
            public double? Valor { get; set; }

            public Informe Informe { get; set; }

      


    }
}
