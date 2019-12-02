namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vendedor")]
    public partial class Vendedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vendedor()
        {
            PedidoCab = new HashSet<PedidoCab>();
        }

        [Key]
        [StringLength(5)]
        public string CodVnd { get; set; }

        [StringLength(300)]
        public string nomvnd { get; set; }

        [StringLength(2)]
        public string tipdoc { get; set; }

        [StringLength(20)]
        public string numdoc { get; set; }

        [StringLength(3)]
        public string estado { get; set; }

        [StringLength(20)]
        public string telefono { get; set; }

        [StringLength(60)]
        public string correo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PedidoCab> PedidoCab { get; set; }
    }
}
