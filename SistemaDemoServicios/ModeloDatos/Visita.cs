namespace SistemaDemoServicios
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Visita")]
    public partial class Visita
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Visita()
        {
            Informe = new HashSet<Informe>();
        }

        public int Id { get; set; }

        public int? IdCliente { get; set; }

        public int? IdAgente { get; set; }

        public DateTime Fecha { get; set; }

        [StringLength(150)]
        public string Observacion { get; set; }

        public int? Tipo { get; set; }

        public DateTime? HoraSalida { get; set; }

        public DateTime? HoraIngreso { get; set; }

        public double? Valor { get; set; }

        public virtual Agente Agente { get; set; }

        public virtual Cliente Cliente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Informe> Informe { get; set; }
    }
}
