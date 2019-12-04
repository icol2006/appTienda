namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TabFotos
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(3)]
        [DisplayName("Tipo")]
        public string Tipo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(6)]
        [DisplayName("Codigo Producto")]
        public string Codigo { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Item")]
        public int item { get; set; }

        [StringLength(200)]
        [DisplayName("Titulo")]
        public string titulo { get; set; }

        [StringLength(2000)]
        [DisplayName("Descripcion")]
        public string descripcion { get; set; }

        [StringLength(1000)]
        [DisplayName("Foto")]
        public string foto { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
