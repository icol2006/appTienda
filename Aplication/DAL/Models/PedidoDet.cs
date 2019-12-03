namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PedidoDet")]
    public partial class PedidoDet
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AnoProc { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(8)]
        public string IdPedido { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(3)]
        public string Item { get; set; }

        [StringLength(6)]
        public string CodPro { get; set; }

        [StringLength(3)]
        public string TipVenta { get; set; }

        public int? Cantidad { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Precio { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SubTotal { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Impuesto { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Descuento { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Total { get; set; }

        [StringLength(4)]
        public string CodAlm { get; set; }

        public virtual PedidoCab PedidoCab { get; set; }
    }
}
