using System;
using Desapega.Negocio;
using System.Windows.Forms;

namespace Desapega.Grafico
{
    public partial class TelaRemoverUsuario : Form
    {
        private string CPF;
        private Usuario usuario;

        public TelaRemoverUsuario(string cpf)
        {

            InitializeComponent();
            this.CPF = cpf;
            usuario = Util.Gerenciador.BuscarUsuarioPorCPF(cpf);
            cbxUsuarios.DataSource = usuario.CPF.Equals(cpf);
            cbxUsuarios.DisplayMember = "Usuário";
            cbxUsuarios.ValueMember = "CPF";
        }

        private void bt_Remover_Click(object sender, EventArgs e)
        {
            Util.Gerenciador.RemoverUsuario(this.usuario.CPF);
            this.Close();
        }

        private void cbxUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TelaRemoverUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}
