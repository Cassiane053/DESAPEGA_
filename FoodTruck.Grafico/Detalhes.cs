using Desapega.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desapega.Grafico
{
    public partial class Detalhes : Form
    {
        private Troca troca;
        public Detalhes(long Id)
        {
            InitializeComponent();
            //this.dgLanches.ReadOnly = true;
            this.dbProdutos.ReadOnly = true;
            this.troca = Util.Gerenciador.BuscarTrocaPorCodigo(Id);
            //this.dgLanches.DataSource = this.pedido.Lanches;
            this.dbProdutos.DataSource = this.troca.Produtos;
            this.lbUsuario.Text = this.troca.Usuario.Nome;
            this.lbId.Text = this.troca.Id.ToString();
            //this.lbTotal.Text = (this.pedido.Bebidas.Sum(e => e.Valor) + this.pedido.Lanches.Sum(e => e.Valor)).ToString();
        }
    }
}
