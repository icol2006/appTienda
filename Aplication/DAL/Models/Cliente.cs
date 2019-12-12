namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cliente")]
    public partial class Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente()
        {
            DomCli = new HashSet<DomCli>();
            PedidoCab = new HashSet<PedidoCab>();
        }

        [Key]
        [StringLength(6)]
        [DisplayName("Codigo cliente")]
        public string CodCli { get; set; }

        [StringLength(300)]
        [Required]
        [DisplayName("Nombre cliente")]
        public string nomcli { get; set; }

        [StringLength(2)]
        [Required]
        [DisplayName("Tipo documento")]
        public string tipdoc { get; set; }

        [StringLength(20)]
        [Required]
        [DisplayName("Numero documento")]
        public string numdoc { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DomCli> DomCli { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PedidoCab> PedidoCab { get; set; }
    }
}
