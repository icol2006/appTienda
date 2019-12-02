namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PedidoCab")]
    public partial class PedidoCab
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PedidoCab()
        {
            PedidoDet = new HashSet<PedidoDet>();
        }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AnoProc { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(8)]
        public string IdPedido { get; set; }

        [StringLength(5)]
        public string CodVnd { get; set; }

        [StringLength(6)]
        public string CodCli { get; set; }

        [StringLength(3)]
        public string CodDom { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha { get; set; }

        [StringLength(3)]
        public string estado { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? BaseImponible { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? VentaExhonerada { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Impuesto { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Descuento { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Total { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaCreacion { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Vendedor Vendedor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PedidoDet> PedidoDet { get; set; }
    }
}
