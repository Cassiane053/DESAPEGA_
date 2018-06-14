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
    public partial class TelaRemoverProdutoTroca : Form
    {
        private Int64 Id;
        private Troca troca;

        public TelaRemoverProdutoTroca(long Id)
        {
            this.Id = Id;
            InitializeComponent();
            troca = Util.Gerenciador.BuscarTrocaPorCodigo(Id);
            cbxProdutos.DataSource = troca.Produtos;
            cbxProdutos.DisplayMember = "Nome";
            cbxProdutos.ValueMember = "Id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //remover produto
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Troca troca = Util.Gerenciador.BuscarTrocaPorCodigo(Id);
                Int64 produtoId = (Int64)cbxProdutos.SelectedValue;
                Util.Gerenciador.RemoverProdutoDaTroca(troca, produtoId);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TelaRemoverProdutoTroca_Shown(object sender, EventArgs e)
        {
            if (troca.Produtos.Count <= 0)
            {
                MessageBox.Show("A solicitação de troca não possui nenhum produto");
                this.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void cbxProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TelaRemoverProdutoTroca_Load(object sender, EventArgs e)
        {

        }
    }
}
