using Desapega.Negocio;
using System;
using System.Windows.Forms;

namespace Desapega.Grafico
{
    public partial class TelaCadastrarUsuario : Form
    {
        private Usuario usuario;
        private Boolean edit = false;

        public TelaCadastrarUsuario()
        {
            InitializeComponent();
            this.usuario = new Usuario();
            this.btRemover.Enabled = false;
        }

        public TelaCadastrarUsuario(String CPF)
        {
            InitializeComponent();
            this.usuario = Util.Gerenciador.BuscarUsuarioPorCPF(CPF);
            this.edit = true;
            tbCpf.Text = this.usuario.CPF.ToString();
            tbCpf.ReadOnly = true;
            tbNome.Text = this.usuario.Nome;
            tbEmail.Text = this.usuario.Email.ToString();
            this.Text = "Alterar Usuário";
        }

        private void Limpar()
        {
            tbCpf.Text = "";
            tbNome.Text = "";
            tbEmail.Text = "";
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario.CPF = tbCpf.Text;
                usuario.Nome = tbNome.Text;
                usuario.Email = tbEmail.Text;
                Util.Gerenciador.AdicionarUsuario(usuario);

                Limpar();
                MessageBox.Show("Usuário adicionado com sucesso!");
                this.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //digitar cpf
        private void tbCpf_TextChanged(object sender, EventArgs e)
        {

        }

        private void imagemCliente_Click(object sender, EventArgs e)
        {

        }

        private void btRemover_Click(object sender, EventArgs e)
        {
            Util.Gerenciador.RemoverUsuario(this.usuario.CPF);
            this.Close();
        }

        private void tbNome_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
