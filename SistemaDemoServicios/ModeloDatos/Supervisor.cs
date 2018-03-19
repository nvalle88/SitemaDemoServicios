namespace SistemaDemoServicios
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Supervisor")]
    public partial class Supervisor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supervisor()
        {
            Agente = new HashSet<Agente>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string Apellido { get; set; }

        [StringLength(50)]
        public string Telefono { get; set; }

        [StringLength(50)]
        public string Correo { get; set; }

        [Required]
        [StringLength(50)]
        public string Contrasena { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Agente> Agente { get; set; }
    }
}
