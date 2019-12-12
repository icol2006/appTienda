namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DomCli")]
    public partial class DomCli
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(6)]
        [DisplayName("Cod Cliente")]
        public string CodCli { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(3)]
        [DisplayName("Cod Domicilio")]
        public string CodDom { get; set; }

        [StringLength(500)]
        [Required]
        [DisplayName("Direccion")]
        public string direccion { get; set; }

        [StringLength(3)]
        [DisplayName("Estado")]
        [Required]
        public string estado { get; set; }

        [StringLength(20)]
        [DisplayName("Telefono")]
        public string telefono { get; set; }

        [StringLength(60)]
        [DisplayName("Correo")]
        public string correo { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
