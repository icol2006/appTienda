namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Producto")]
    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            KardexProductos = new HashSet<KardexProductos>();
            ProAlm = new HashSet<ProAlm>();
            TabFotos = new HashSet<TabFotos>();
        }

        [Key]
        [StringLength(6)]
        public string CodPro { get; set; }

        [StringLength(4)]
        public string CodLin { get; set; }

        [StringLength(4)]
        public string CodSubLin { get; set; }

        [StringLength(500)]
        public string NomPro { get; set; }

        [StringLength(3)]
        public string estado { get; set; }

        [StringLength(3)]
        public string CodUniMed { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? precio { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? afectoigv { get; set; }

        [StringLength(2)]
        public string TipPro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KardexProductos> KardexProductos { get; set; }

        public virtual LineaProducto LineaProducto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProAlm> ProAlm { get; set; }

        public virtual SubLineaProducto SubLineaProducto { get; set; }

        public virtual UnidadMedida UnidadMedida { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TabFotos> TabFotos { get; set; }
    }
}
