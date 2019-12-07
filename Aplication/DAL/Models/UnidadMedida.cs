namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UnidadMedida")]
    public partial class UnidadMedida
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UnidadMedida()
        {
            Producto = new HashSet<Producto>();
        }

        [Key]
        [StringLength(3)]
        [DisplayName("Codigo medida")]
        public string CodUnidadMed { get; set; }

        [StringLength(50)]
        [DisplayName("Descripcion Unidad")]
        public string DesUniMed { get; set; }

        [StringLength(3)]
        [DisplayName("Estado")]
        public string Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Producto> Producto { get; set; }
    }
}
