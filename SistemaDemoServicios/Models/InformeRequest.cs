using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaDemoServicios.Models
{
    public class InformeRequest
    {
        public int Id { get; set; }
        public int IdVisita { get; set; }
        public int Calificacion { get; set; }
        public string PendienteComercial { get; set; }
        public string SolucionComercial { get; set; }
        public string PendienteServicio { get; set; }
        public string SolucionServicio { get; set; }
        public string NuevoNegocio { get; set; }
        public string Otros { get; set; }
        public string UrlFirma { get; set; }
    }
}