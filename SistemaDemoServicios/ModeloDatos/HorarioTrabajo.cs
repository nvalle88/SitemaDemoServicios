namespace SistemaDemoServicios
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HorarioTrabajo")]
    public partial class HorarioTrabajo
    {
        public int Id { get; set; }

        public int DiaSemanaInicial { get; set; }

        public int DiaSemanaFinal { get; set; }

        [Required]
        [StringLength(50)]
        public string HoraInicio { get; set; }

        [Required]
        [StringLength(50)]
        public string HoraFinal { get; set; }
    }
}
