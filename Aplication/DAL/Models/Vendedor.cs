namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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
        [DisplayName("Codigo vendedor")]
        public string CodVnd { get; set; }

        [StringLength(300)]
        [DisplayName("Nombre vendedor")]
        public string nomvnd { get; set; }

        [StringLength(2)]
        [DisplayName("Tipo documento")]
        public string tipdoc { get; set; }

        [StringLength(20)]
        [DisplayName("Numero documento")]
        public string numdoc { get; set; }

        [StringLength(3)]
        [DisplayName("Estado")]
        public string estado { get; set; }

        [StringLength(20)]
        [DisplayName("Telefono")]
        public string telefono { get; set; }

        [StringLength(60)]
        [DisplayName("Correo")]
        public string correo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PedidoCab> PedidoCab { get; set; }
    }
}
