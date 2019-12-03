namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TabFotos
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(3)]
        public string Tipo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(6)]
        public string Codigo { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int item { get; set; }

        [StringLength(200)]
        public string titulo { get; set; }

        [StringLength(2000)]
        public string descripcion { get; set; }

        [StringLength(1000)]
        public string foto { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
