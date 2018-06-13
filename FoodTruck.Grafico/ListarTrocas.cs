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
    public partial class ListarTrocas : Form
    {
        public ListarTrocas()
        {
            InitializeComponent();
            dgTrocas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgTrocas.MultiSelect = false;
            dgTrocas.ReadOnly = true;
        }

        private void CarregarDados()
        {
            List<Troca> trocas = Util.Gerenciador.TrocasCadastradas();
            dgTrocas.DataSource = trocas;
        }

        private void ListarTrocas_Load(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void btAtualizar_Click(object sender, EventArgs e)
        {
            CarregarDados();
        }

        //adiciona uma troca
        private void btAdicionar_Click(object sender, EventArgs e)
        {
            TelaCadastrarTroca tela = new TelaCadastrarTroca();
            tela.MdiParent = this.MdiParent;
            tela.FormClosed += Tela_FormClosed;
            tela.Show();
        }

        private void Tela_FormClosed(object sender, FormClosedEventArgs e)
        {
            CarregarDados();
        }

        //adiciona um produto
        private void tbAdicionarProduto_Click(object sender, EventArgs e)
        {
            if (dgTrocas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um produto");
                return;
            }

            Int64 trocaId = (Int64) dgTrocas.SelectedRows[0].Cells[0].Value;
            TelaAdicionarProdutoTroca tela = new TelaAdicionarProdutoTroca();
            tela.FormClosed += Tela_FormClosed1;
            tela.PedidoId = trocaId;
            tela.MdiParent = this.MdiParent;
            tela.Show();
        }

        private void Tela_FormClosed1(object sender, FormClosedEventArgs e)
        {
            CarregarDados();
        }

        
        /*private void tbLanche_Click(object sender, EventArgs e)
        {
            if (dgTrocas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione o pedido");
                return;
            }

            Int64 pedidoId = (Int64)dgTrocas.SelectedRows[0].Cells[0].Value;
            TelaAdicionarLanchePedido tela = new TelaAdicionarLanchePedido();
            tela.FormClosed += Tela_FormClosed1;
            tela.PedidoId = pedidoId;
            tela.MdiParent = this.MdiParent;
            tela.Show();
        }*/

        private void btnRemoverProduto_Click(object sender, EventArgs e)
        {
            if (dgTrocas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um produto para troca");
                return;
            }

            Int64 trocaId = (Int64)dgTrocas.SelectedRows[0].Cells[0].Value;
            TelaRemoverProdutoTroca tela = new TelaRemoverProdutoTroca(trocaId);
            tela.FormClosed += Tela_FormClosed1;
            tela.MdiParent = this.MdiParent;
            tela.Show();
        }

        /*private void btnRemoverLanche_Click(object sender, EventArgs e)
        {
            if (dgTrocas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um pedido");
                return;
            }

            Int64 trocaId = (Int64)dgTrocas.SelectedRows[0].Cells[0].Value;
            TelaRemoverLanchePedido tela = new TelaRemoverLanchePedido(pedidoId);
            tela.FormClosed += Tela_FormClosed1;
            tela.MdiParent = this.MdiParent;
            tela.Show();
        }*/

        private void dgTrocas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
