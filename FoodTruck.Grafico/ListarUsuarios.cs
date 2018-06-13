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
            dgUsuario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgUsuario.ColumnCount = 3;
            dgUsuario.ColumnHeadersVisible = true;
            dgUsuario.Columns[0].Name = "CPF";
            dgUsuario.Columns[0].DataPropertyName = "CPF";
            dgUsuario.Columns[0].ReadOnly = true;
            dgUsuario.Columns[1].Name = "Nome";
            dgUsuario.Columns[1].DataPropertyName = "Nome";
            dgUsuario.Columns[1].ReadOnly = true;
            dgUsuario.Columns[2].Name = "Email";
            dgUsuario.Columns[2].DataPropertyName = "Email";
            dgUsuario.Columns[2].ReadOnly = true;
            dgUsuario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void Atualizar()
        {
            List<Usuario> usuarios = Util.Gerenciador.UsuariosCadastrados();
            dgUsuario.DataSource = usuarios;
        }

        
        private void ListarUsuarios_Load(object sender, EventArgs e)
        {
            Atualizar();
        }

        private void btAtualizar_Click(object sender, EventArgs e)
        {
            Atualizar();
        }

        private void tbCadastrarUsuario_Click(object sender, EventArgs e)
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

        private void dgUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            object obj = Util.GetCellValueFromColumnHeader(dgUsuario.SelectedRows[0].Cells, "CPF");

            if (obj == null)
                return;

            String CPF = (String)Util.GetCellValueFromColumnHeader(dgUsuario.SelectedRows[0].Cells, "CPF");

            TelaCadastrarUsuario tela = new TelaCadastrarUsuario(CPF);
            tela.FormClosed += Tela_FormClosed;
            tela.MdiParent = this.MdiParent;
            tela.Show();

        }
    }
}
