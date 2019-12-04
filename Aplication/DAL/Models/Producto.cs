namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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
        [DisplayName("Codigo producto")]
        public string CodPro { get; set; }

        [StringLength(4)]
        [DisplayName("Codigo linea")]
        public string CodLin { get; set; }

        [StringLength(4)]
        [DisplayName("Codigo sublinea")]
        public string CodSubLin { get; set; }

        [StringLength(500)]
        [DisplayName("Nombre producto")]
        public string NomPro { get; set; }

        [StringLength(3)]
        [DisplayName("Estado")]
        public string estado { get; set; }

        [StringLength(3)]
        [DisplayName("Codigo unidad")]
        public string CodUniMed { get; set; }

        [Column(TypeName = "numeric")]
        [DisplayName("Precio")]
        public decimal? precio { get; set; }

        [Column(TypeName = "numeric")]
        [DisplayName("afectoigv")]
        public decimal? afectoigv { get; set; }

        [StringLength(2)]
        [DisplayName("Tipo Producto")]
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
