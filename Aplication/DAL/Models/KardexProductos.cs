namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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
        [DisplayName("Id")]
        public string IdKardex { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Fecha")]
        public DateTime? Fecha { get; set; }

        [StringLength(6)]
        [DisplayName("Cod producto")]
        public string CodPro { get; set; }

        [StringLength(4)]
        [DisplayName("Cod Almacen")]
        public string CodAlm { get; set; }

        [StringLength(2)]
        [DisplayName("Tipo Operacion")]
        public string TipoOperacion { get; set; }

        [DisplayName("Stok inicio")]
        public int? StokIni { get; set; }

        [DisplayName("Cantidad")]
        public int? cantidad { get; set; }

        [DisplayName("Stok Final")]
        public int? StokFin { get; set; }

        [StringLength(8)]
        [DisplayName("Id Operacion")]
        public string IdOperacion { get; set; }

        [StringLength(20)]
        [DisplayName("Modulo operacion")]
        public string ModuloOperacion { get; set; }

        [DisplayName("Fecha Creacion")]
        public DateTime? FechaCreacion { get; set; }

        public virtual Almacen Almacen { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
