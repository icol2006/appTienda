using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly IVendedorRepository vendedorRepository;
        private readonly IDomCliRepository domCliRepository;
        private readonly ClienteRepository clienteRepository;

        public Form1()
        {
            InitializeComponent();
            vendedorRepository = new VendedorRepository();
            domCliRepository = new DomCliRepository();
            clienteRepository = new ClienteRepository();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //
            var da = this.vendedorRepository.GetOne(x=>x.CodVnd.Equals("2"), new string[] { "PedidoCab" });

            Vendedor v = new Vendedor();
            v.CodVnd = "3";
            v.correo = "correo33";
            v.estado = "3";
            v.nomvnd = "vendedor3";
            v.telefono = "telefono3";
            v.tipdoc = "3";

            // this.vendedorRepository.Update(v);

            //  this.vendedorRepository.Delete("3");
            var ss = this.clienteRepository.GetList(null, null);
            var sp = this.clienteRepository.GetOne(x => x.CodCli.Equals("3"),null);
            //var pp= this.vendedorRepository.AllIncluding((x => x.CodVnd==("1")),null).ToList();
            var uads = sp.correo;
            //this.vendedorRepository.Save();

            int s = 0;
        }
    }
}
