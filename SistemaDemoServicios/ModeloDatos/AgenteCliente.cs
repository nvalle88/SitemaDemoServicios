namespace SistemaDemoServicios
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AgenteCliente")]
    public partial class AgenteCliente
    {
        public int Id { get; set; }

        public int? IdAgente { get; set; }

        public int? IdCliente { get; set; }

        public virtual Agente Agente { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
