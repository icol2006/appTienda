namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LineaProducto")]
    public partial class LineaProducto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LineaProducto()
        {
            Producto = new HashSet<Producto>();
            SubLineaProducto = new HashSet<SubLineaProducto>();
        }

        [Key]
        [StringLength(4)]
        [DisplayName("Codigo linea")]
        public string CodLin { get; set; }

        [StringLength(100)]
        [DisplayName("Descripcion linea")]
        public string DesLin { get; set; }

        [StringLength(3)]
        [DisplayName("Estado")]
        public string Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Producto> Producto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubLineaProducto> SubLineaProducto { get; set; }
    }
}
