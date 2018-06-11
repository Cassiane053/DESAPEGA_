using FoodTruck.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodTruck.Grafico
{
    public partial class ListarUsuarios : Form
    {
        public ListarUsuarios()
        {
            InitializeComponent();
            ConfigurarDatagrid();
        }

        //modo como as colunas vão ficar
        private void ConfigurarDatagrid()
        {
            dgCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgCliente.ColumnCount = 3;
            dgCliente.ColumnHeadersVisible = true;
            dgCliente.Columns[0].Name = "CPF";
            dgCliente.Columns[0].DataPropertyName = "CPF";
            dgCliente.Columns[0].ReadOnly = true;
            dgCliente.Columns[1].Name = "Nome";
            dgCliente.Columns[1].DataPropertyName = "Nome";
            dgCliente.Columns[1].ReadOnly = true;
            dgCliente.Columns[2].Name = "Email";
            dgCliente.Columns[2].DataPropertyName = "Email";
            dgCliente.Columns[2].ReadOnly = true;
            dgCliente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void Atualizar()
        {
            List<Usuario> clientes = Util.Gerenciador.ClientesCadastrados();
            dgCliente.DataSource = clientes;
        }

        
        private void ListarClientes_Load(object sender, EventArgs e)
        {
            Atualizar();
        }

        private void btAtualizar_Click(object sender, EventArgs e)
        {
            Atualizar();
        }

        private void tbCadastrarCliente_Click(object sender, EventArgs e)
        {
            TelaCadastrarUsuario cadastro = new TelaCadastrarUsuario();
            cadastro.FormClosed += Cadastro_FormClosed;
            cadastro.MdiParent = this.MdiParent;
            cadastro.Show();
        }

        private void Cadastro_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            Atualizar();
        }

        private void Tela_FormClosed(object sender, FormClosedEventArgs e)
        {
            Atualizar();
        }

        private void dgCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            object obj = Util.GetCellValueFromColumnHeader(dgCliente.SelectedRows[0].Cells, "CPF");

            if (obj == null)
                return;

            String CPF = (String)Util.GetCellValueFromColumnHeader(dgCliente.SelectedRows[0].Cells, "CPF");

            TelaCadastrarUsuario tela = new TelaCadastrarUsuario(CPF);
            tela.FormClosed += Tela_FormClosed;
            tela.MdiParent = this.MdiParent;
            tela.Show();

        }
    }
}
