namespace DAL.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WebDatabaseContext : DbContext
    {
        public WebDatabaseContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<Almacen> Almacen { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<CompraCab> CompraCab { get; set; }
        public virtual DbSet<CompraDet> CompraDet { get; set; }
        public virtual DbSet<DevolucionCab> DevolucionCab { get; set; }
        public virtual DbSet<DevolucionDet> DevolucionDet { get; set; }
        public virtual DbSet<DocSunCab> DocSunCab { get; set; }
        public virtual DbSet<DocSunDet> DocSunDet { get; set; }
        public virtual DbSet<DomCli> DomCli { get; set; }
        public virtual DbSet<KardexProductos> KardexProductos { get; set; }
        public virtual DbSet<LineaProducto> LineaProducto { get; set; }
        public virtual DbSet<PedidoCab> PedidoCab { get; set; }
        public virtual DbSet<PedidoDet> PedidoDet { get; set; }
        public virtual DbSet<ProAlm> ProAlm { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<SubLineaProducto> SubLineaProducto { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TabFotos> TabFotos { get; set; }
        public virtual DbSet<UnidadMedida> UnidadMedida { get; set; }
        public virtual DbSet<Vendedor> Vendedor { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Almacen>()
                .Property(e => e.CodAlm)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Almacen>()
                .Property(e => e.DesAlm)
                .IsUnicode(false);

            modelBuilder.Entity<Almacen>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<Almacen>()
                .HasMany(e => e.ProAlm)
                .WithRequired(e => e.Almacen)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.CodCli)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.nomcli)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.tipdoc)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.numdoc)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.correo)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.DomCli)
                .WithRequired(e => e.Cliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompraCab>()
                .Property(e => e.IdCompra)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CompraCab>()
                .Property(e => e.CodPrv)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CompraCab>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CompraCab>()
                .Property(e => e.BaseImposible)
                .HasPrecision(18, 3);

            modelBuilder.Entity<CompraCab>()
                .Property(e => e.VentaExhonerado)
                .HasPrecision(18, 4);

            modelBuilder.Entity<CompraCab>()
                .Property(e => e.Impuesto)
                .HasPrecision(18, 4);

            modelBuilder.Entity<CompraCab>()
                .Property(e => e.Descuento)
                .HasPrecision(18, 4);

            modelBuilder.Entity<CompraCab>()
                .Property(e => e.Total)
                .HasPrecision(18, 4);

            modelBuilder.Entity<CompraCab>()
                .HasMany(e => e.CompraDet)
                .WithRequired(e => e.CompraCab)
                .HasForeignKey(e => new { e.AnoProc, e.IdCompra })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompraDet>()
                .Property(e => e.IdCompra)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CompraDet>()
                .Property(e => e.item)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CompraDet>()
                .Property(e => e.CodPro)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CompraDet>()
                .Property(e => e.Precio)
                .HasPrecision(18, 4);

            modelBuilder.Entity<CompraDet>()
                .Property(e => e.SubTotal)
                .HasPrecision(18, 4);

            modelBuilder.Entity<CompraDet>()
                .Property(e => e.Impuesto)
                .HasPrecision(18, 4);

            modelBuilder.Entity<CompraDet>()
                .Property(e => e.Descuento)
                .HasPrecision(18, 4);

            modelBuilder.Entity<CompraDet>()
                .Property(e => e.Total)
                .HasPrecision(18, 4);

            modelBuilder.Entity<CompraDet>()
                .Property(e => e.CodAlm)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DevolucionCab>()
                .Property(e => e.IdDevolucion)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DevolucionCab>()
                .Property(e => e.CodCli)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DevolucionCab>()
                .Property(e => e.CodDom)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DevolucionCab>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DevolucionCab>()
                .Property(e => e.BaseImposible)
                .HasPrecision(18, 4);

            modelBuilder.Entity<DevolucionCab>()
                .Property(e => e.VentaExhonerada)
                .HasPrecision(18, 4);

            modelBuilder.Entity<DevolucionCab>()
                .Property(e => e.Impuesto)
                .HasPrecision(18, 4);

            modelBuilder.Entity<DevolucionCab>()
                .Property(e => e.Descuento)
                .HasPrecision(18, 4);

            modelBuilder.Entity<DevolucionCab>()
                .Property(e => e.Total)
                .HasPrecision(18, 4);

            modelBuilder.Entity<DevolucionCab>()
                .HasMany(e => e.DevolucionDet)
                .WithRequired(e => e.DevolucionCab)
                .HasForeignKey(e => new { e.AnoProc, e.IdDevolucion })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DevolucionDet>()
                .Property(e => e.IdDevolucion)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DevolucionDet>()
                .Property(e => e.Item)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DevolucionDet>()
                .Property(e => e.CodPro)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DevolucionDet>()
                .Property(e => e.Precio)
                .HasPrecision(18, 4);

            modelBuilder.Entity<DevolucionDet>()
                .Property(e => e.SubTotal)
                .HasPrecision(18, 4);

            modelBuilder.Entity<DevolucionDet>()
                .Property(e => e.Impuesto)
                .HasPrecision(18, 4);

            modelBuilder.Entity<DevolucionDet>()
                .Property(e => e.Descuento)
                .HasPrecision(18, 4);

            modelBuilder.Entity<DevolucionDet>()
                .Property(e => e.Total)
                .HasPrecision(18, 4);

            modelBuilder.Entity<DevolucionDet>()
                .Property(e => e.IdDocSun)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DevolucionDet>()
                .Property(e => e.CodAlm)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DocSunCab>()
                .Property(e => e.IdDocSun)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DocSunCab>()
                .Property(e => e.CodProc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DocSunCab>()
                .Property(e => e.Serie)
                .IsUnicode(false);

            modelBuilder.Entity<DocSunCab>()
                .Property(e => e.Numero)
                .IsUnicode(false);

            modelBuilder.Entity<DocSunCab>()
                .Property(e => e.CodVnd)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DocSunCab>()
                .Property(e => e.CodCli)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DocSunCab>()
                .Property(e => e.CodDom)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DocSunCab>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DocSunCab>()
                .Property(e => e.IdPedido)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DocSunCab>()
                .Property(e => e.IdDevolucion)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DocSunCab>()
                .Property(e => e.BaseImposible)
                .HasPrecision(18, 4);

            modelBuilder.Entity<DocSunCab>()
                .Property(e => e.VentaExhonerada)
                .HasPrecision(18, 4);

            modelBuilder.Entity<DocSunCab>()
                .Property(e => e.Impuesto)
                .HasPrecision(18, 4);

            modelBuilder.Entity<DocSunCab>()
                .Property(e => e.Total)
                .HasPrecision(18, 4);

            modelBuilder.Entity<DocSunCab>()
                .HasMany(e => e.DocSunDet)
                .WithRequired(e => e.DocSunCab)
                .HasForeignKey(e => new { e.AnoProc, e.IdDocSun })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DocSunDet>()
                .Property(e => e.IdDocSun)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DocSunDet>()
                .Property(e => e.Item)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DocSunDet>()
                .Property(e => e.CodPro)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DocSunDet>()
                .Property(e => e.TipVenta)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DocSunDet>()
                .Property(e => e.Precio)
                .HasPrecision(18, 4);

            modelBuilder.Entity<DocSunDet>()
                .Property(e => e.SubTotal)
                .HasPrecision(18, 4);

            modelBuilder.Entity<DocSunDet>()
                .Property(e => e.Impuesto)
                .HasPrecision(18, 4);

            modelBuilder.Entity<DocSunDet>()
                .Property(e => e.Descuento)
                .HasPrecision(18, 4);

            modelBuilder.Entity<DocSunDet>()
                .Property(e => e.Total)
                .HasPrecision(18, 4);

            modelBuilder.Entity<DocSunDet>()
                .Property(e => e.CodAlm)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DomCli>()
                .Property(e => e.CodCli)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DomCli>()
                .Property(e => e.CodDom)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DomCli>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<DomCli>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DomCli>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<DomCli>()
                .Property(e => e.correo)
                .IsUnicode(false);

            modelBuilder.Entity<KardexProductos>()
                .Property(e => e.IdKardex)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KardexProductos>()
                .Property(e => e.CodPro)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KardexProductos>()
                .Property(e => e.CodAlm)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KardexProductos>()
                .Property(e => e.TipoOperacion)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KardexProductos>()
                .Property(e => e.IdOperacion)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KardexProductos>()
                .Property(e => e.ModuloOperacion)
                .IsUnicode(false);

            modelBuilder.Entity<LineaProducto>()
                .Property(e => e.CodLin)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LineaProducto>()
                .Property(e => e.DesLin)
                .IsUnicode(false);

            modelBuilder.Entity<LineaProducto>()
                .Property(e => e.Estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PedidoCab>()
                .Property(e => e.IdPedido)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PedidoCab>()
                .Property(e => e.CodVnd)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PedidoCab>()
                .Property(e => e.CodCli)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PedidoCab>()
                .Property(e => e.CodDom)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PedidoCab>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PedidoCab>()
                .Property(e => e.BaseImponible)
                .HasPrecision(18, 4);

            modelBuilder.Entity<PedidoCab>()
                .Property(e => e.VentaExhonerada)
                .HasPrecision(18, 4);

            modelBuilder.Entity<PedidoCab>()
                .Property(e => e.Impuesto)
                .HasPrecision(18, 4);

            modelBuilder.Entity<PedidoCab>()
                .Property(e => e.Descuento)
                .HasPrecision(18, 4);

            modelBuilder.Entity<PedidoCab>()
                .Property(e => e.Total)
                .HasPrecision(18, 4);

            modelBuilder.Entity<PedidoCab>()
                .HasMany(e => e.PedidoDet)
                .WithRequired(e => e.PedidoCab)
                .HasForeignKey(e => new { e.AnoProc, e.IdPedido })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PedidoDet>()
                .Property(e => e.IdPedido)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PedidoDet>()
                .Property(e => e.Item)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PedidoDet>()
                .Property(e => e.CodPro)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PedidoDet>()
                .Property(e => e.TipVenta)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PedidoDet>()
                .Property(e => e.Precio)
                .HasPrecision(18, 4);

            modelBuilder.Entity<PedidoDet>()
                .Property(e => e.SubTotal)
                .HasPrecision(18, 4);

            modelBuilder.Entity<PedidoDet>()
                .Property(e => e.Impuesto)
                .HasPrecision(18, 4);

            modelBuilder.Entity<PedidoDet>()
                .Property(e => e.Descuento)
                .HasPrecision(18, 4);

            modelBuilder.Entity<PedidoDet>()
                .Property(e => e.Total)
                .HasPrecision(18, 4);

            modelBuilder.Entity<PedidoDet>()
                .Property(e => e.CodAlm)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ProAlm>()
                .Property(e => e.CodAlm)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ProAlm>()
                .Property(e => e.CodPro)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.CodPro)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.CodLin)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.CodSubLin)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.NomPro)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.CodUniMed)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.precio)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Producto>()
                .Property(e => e.afectoigv)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Producto>()
                .Property(e => e.TipPro)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.ProAlm)
                .WithRequired(e => e.Producto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.TabFotos)
                .WithRequired(e => e.Producto)
                .HasForeignKey(e => e.Codigo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.CodPrv)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.NomPrv)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.tipdoc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.numdoc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.correo)
                .IsUnicode(false);

            modelBuilder.Entity<SubLineaProducto>()
                .Property(e => e.CodSubLin)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SubLineaProducto>()
                .Property(e => e.CodLin)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SubLineaProducto>()
                .Property(e => e.DesLin)
                .IsUnicode(false);

            modelBuilder.Entity<SubLineaProducto>()
                .Property(e => e.Estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TabFotos>()
                .Property(e => e.Tipo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TabFotos>()
                .Property(e => e.Codigo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TabFotos>()
                .Property(e => e.titulo)
                .IsUnicode(false);

            modelBuilder.Entity<TabFotos>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<TabFotos>()
                .Property(e => e.foto)
                .IsUnicode(false);

            modelBuilder.Entity<UnidadMedida>()
                .Property(e => e.CodUnidadMed)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UnidadMedida>()
                .Property(e => e.DesUniMed)
                .IsUnicode(false);

            modelBuilder.Entity<UnidadMedida>()
                .Property(e => e.Estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UnidadMedida>()
                .HasMany(e => e.Producto)
                .WithOptional(e => e.UnidadMedida)
                .HasForeignKey(e => e.CodUniMed);

            modelBuilder.Entity<Vendedor>()
                .Property(e => e.CodVnd)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Vendedor>()
                .Property(e => e.nomvnd)
                .IsUnicode(false);

            modelBuilder.Entity<Vendedor>()
                .Property(e => e.tipdoc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Vendedor>()
                .Property(e => e.numdoc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Vendedor>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Vendedor>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Vendedor>()
                .Property(e => e.correo)
                .IsUnicode(false);
        }
    }
}
