namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DocSunCab")]
    public partial class DocSunCab
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DocSunCab()
        {
            DocSunDet = new HashSet<DocSunDet>();
        }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AnoProc { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(8)]
        public string IdDocSun { get; set; }

        [StringLength(6)]
        public string CodProc { get; set; }

        [StringLength(4)]
        public string Serie { get; set; }

        [StringLength(10)]
        public string Numero { get; set; }

        [StringLength(5)]
        public string CodVnd { get; set; }

        [StringLength(6)]
        public string CodCli { get; set; }

        [StringLength(3)]
        public string CodDom { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha { get; set; }

        [StringLength(3)]
        public string estado { get; set; }

        public int? AnoProcPedido { get; set; }

        [StringLength(8)]
        public string IdPedido { get; set; }

        public int? AnoProcDev { get; set; }

        [StringLength(8)]
        public string IdDevolucion { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? BaseImposible { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? VentaExhonerada { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Impuesto { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Total { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaCreacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocSunDet> DocSunDet { get; set; }
    }
}
