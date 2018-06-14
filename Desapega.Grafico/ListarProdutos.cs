using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Desapega.Negocio;

namespace Desapega.Grafico
{
    public partial class ListarProdutos : Form
    {
        public ListarProdutos()
        {
            InitializeComponent();
            ConfigurarDg();
        }

        //o que vai aparecer na lista
        private void ConfigurarDg()
        {
            dgProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgProdutos.ColumnCount = 4;
            dgProdutos.ColumnHeadersVisible = true;
            dgProdutos.Columns[0].Name = "Código";
            dgProdutos.Columns[0].DataPropertyName = "Id";
            dgProdutos.Columns[0].ReadOnly = true;
            dgProdutos.Columns[1].Name = "Nome";
            dgProdutos.Columns[1].DataPropertyName = "Nome";
            dgProdutos.Columns[1].ReadOnly = true;
            dgProdutos.Columns[2].Name = "Preço";
            dgProdutos.Columns[2].DataPropertyName = "Valor";
            dgProdutos.Columns[2].ReadOnly = true;
            dgProdutos.Columns[3].Name = "Tamanho (ml)";
            dgProdutos.Columns[3].DataPropertyName = "Tamanho";
            dgProdutos.Columns[3].ReadOnly = true;
            dgProdutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        //puxa os produtos inseridos na lista
        private void CarregarDados()
        {
            List<Produto> produtos = Util.Gerenciador.ProdutosCadastrados();
            dgProdutos.DataSource = produtos;
        }

        private void ListarProdutos_Load(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void btAtualizar_Click(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void btAdicionar_Click(object sender, EventArgs e)
        {
            TelaCadastrarProduto tela = new TelaCadastrarProduto();
            tela.FormClosed += Tela_FormClosed;
            tela.MdiParent = this.MdiParent;
            tela.Show();
        }

        private void Tela_FormClosed(object sender, FormClosedEventArgs e)
        {
            CarregarDados();
        }

        private void dgProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            object obj = Util.GetCellValueFromColumnHeader(dgProdutos.SelectedRows[0].Cells, "Id");

            if (obj == null)
                return;

            long Id = (long)Util.GetCellValueFromColumnHeader(dgProdutos.SelectedRows[0].Cells, "Id");

            TelaCadastrarProduto tela = new TelaCadastrarProduto(Id);
            tela.FormClosed += Tela_FormClosed;
            tela.MdiParent = this.MdiParent;
            tela.Show();
        }

        private void dgProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
