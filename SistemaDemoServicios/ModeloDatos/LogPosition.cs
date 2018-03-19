namespace SistemaDemoServicios
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LogPosition")]
    public partial class LogPosition
    {
        public int id { get; set; }

        public int? idAgente { get; set; }

        public double? Lat { get; set; }

        public double? Lon { get; set; }

        public DateTime? Fecha { get; set; }

        public virtual Agente Agente { get; set; }
    }
}
