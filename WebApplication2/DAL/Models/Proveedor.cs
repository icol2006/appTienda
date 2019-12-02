namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
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
        public string CodPrv { get; set; }

        [StringLength(500)]
        public string NomPrv { get; set; }

        [StringLength(3)]
        public string estado { get; set; }

        [StringLength(2)]
        public string tipdoc { get; set; }

        [StringLength(20)]
        public string numdoc { get; set; }

        [StringLength(60)]
        public string correo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompraCab> CompraCab { get; set; }
    }
}
