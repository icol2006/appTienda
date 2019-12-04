namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Proveedor")]
    public partial class Proveedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proveedor()
        {
            CompraCab = new HashSet<CompraCab>();
        }

        [Key]
        [StringLength(6)]
        [DisplayName("Codigo Proveedor")]
        public string CodPrv { get; set; }

        [StringLength(500)]
        [DisplayName("Nombre Proveedor")]
        public string NomPrv { get; set; }

        [StringLength(3)]
        [DisplayName("Estado")]
        public string estado { get; set; }

        [StringLength(2)]
        [DisplayName("Tipo documento")]
        public string tipdoc { get; set; }

        [StringLength(20)]
        [DisplayName("Numero documento")]
        public string numdoc { get; set; }

        [StringLength(60)]
        [DisplayName("Correo")]
        public string correo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompraCab> CompraCab { get; set; }
    }
}
