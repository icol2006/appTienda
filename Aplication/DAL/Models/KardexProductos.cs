namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KardexProductos
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AnoProc { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(8)]
        public string IdKardex { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha { get; set; }

        [StringLength(6)]
        public string CodPro { get; set; }

        [StringLength(4)]
        public string CodAlm { get; set; }

        [StringLength(2)]
        public string TipoOperacion { get; set; }

        public int? StokIni { get; set; }

        public int? cantidad { get; set; }

        public int? StokFin { get; set; }

        [StringLength(8)]
        public string IdOperacion { get; set; }

        [StringLength(20)]
        public string ModuloOperacion { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public virtual Almacen Almacen { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
