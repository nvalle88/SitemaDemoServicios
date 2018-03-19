namespace SistemaDemoServicios
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Alarma")]
    public partial class Alarma
    {
        public int Id { get; set; }

        public int Minutos { get; set; }
    }
}
