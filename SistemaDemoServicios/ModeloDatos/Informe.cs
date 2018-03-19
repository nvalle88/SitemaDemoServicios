namespace SistemaDemoServicios
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Informe")]
    public partial class Informe
    {
        public int Id { get; set; }

        public int? IdVisita { get; set; }

        public int? Calificacion { get; set; }

        [StringLength(1000)]
        public string PendienteComercial { get; set; }

        [StringLength(1000)]
        public string SolucionComercial { get; set; }

        [StringLength(1000)]
        public string PendienteServicio { get; set; }

        [StringLength(1000)]
        public string SolucionServicio { get; set; }

        [StringLength(1000)]
        public string NuevoNegocio { get; set; }

        [StringLength(1000)]
        public string Otros { get; set; }

        [StringLength(1000)]
        public string UrlFirma { get; set; }

        public virtual Visita Visita { get; set; }
    }
}
