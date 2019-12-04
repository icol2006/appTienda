namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SubLineaProducto")]
    public partial class SubLineaProducto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SubLineaProducto()
        {
            Producto = new HashSet<Producto>();
        }

        [Key]
        [StringLength(4)]
        [DisplayName("Codigo sublinea")]
        public string CodSubLin { get; set; }

        [StringLength(4)]
        [DisplayName("Codigo linea")]
        public string CodLin { get; set; }

        [StringLength(100)]
        [DisplayName("Descripcion sublinea")]
        public string DesLin { get; set; }

        [StringLength(3)]
        [DisplayName("Estado")]
        public string Estado { get; set; }

        public virtual LineaProducto LineaProducto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Producto> Producto { get; set; }
    }
}
