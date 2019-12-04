namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProAlm")]
    public partial class ProAlm
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        [DisplayName("Codigo Almacen")]
        public string CodAlm { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(6)]
        [DisplayName("Codigo Producto")]
        public string CodPro { get; set; }

        [DisplayName("Stok")]
        public int? Stock { get; set; }

        public virtual Almacen Almacen { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
