namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Almacen")]
    public partial class Almacen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Almacen()
        {
            KardexProductos = new HashSet<KardexProductos>();
            ProAlm = new HashSet<ProAlm>();
        }

        [Key]
        [StringLength(4)]
        [DisplayName("Codigo Almacen")]
        public string CodAlm { get; set; }

        [StringLength(100)]
        [DisplayName("Descripcion Almacen")]
        public string DesAlm { get; set; }

        [StringLength(3)]
        [DisplayName("Estado")]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KardexProductos> KardexProductos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProAlm> ProAlm { get; set; }
    }
}
