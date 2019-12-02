namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DomCli")]
    public partial class DomCli
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(6)]
        public string CodCli { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(3)]
        public string CodDom { get; set; }

        [StringLength(500)]
        public string direccion { get; set; }

        [StringLength(3)]
        public string estado { get; set; }

        [StringLength(20)]
        public string telefono { get; set; }

        [StringLength(60)]
        public string correo { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
