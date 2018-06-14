
using Desapega.Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Desapega.Grafico
{
    public partial class TelaCadastrarTroca : Form
    {
        public TelaCadastrarTroca()
        {
            InitializeComponent();
            ConfigurarCombobox();
        }

        private void ConfigurarCombobox()
        {
            cbUsuario.DisplayMember = "Nome";
            cbUsuario.ValueMember = "CPF";
        }

        private void CarregarComboboxUsuarios()
        {
            List<Usuario> usuarios = Util.Gerenciador.UsuariosCadastrados();
            cbUsuario.DataSource = usuarios;
        }

        //carrega troca
        private void TelaCadastrarTroca_Load(object sender, EventArgs e)
        {
            CarregarComboboxUsuarios();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Troca troca = new Troca();
                pedido.Id = Convert.ToInt64(tbId.Text);
                pedido.Data = DateTime.ParseExact(tbData.Text, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                String clienteCpf = (String)cbUsuario.SelectedValue;
                pedido.Cliente = Util.Gerenciador.BuscarClientePorCPF(clienteCpf);
                Util.Gerenciador.AdicionarPedido(pedido);
                MessageBox.Show("Troca cadastrada com sucesso!");
                
                this.Close();                 
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbId_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbId.Text))
                return;

            long bebidaId = 0;
            if (!Int64.TryParse(tbId.Text, out bebidaId))
                tbId.Text = tbId.Text.Substring(0, tbId.Text.Length - 1);


        }

        //testar data
        private void tbData_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbData.Text))
                return;

            DateTime dataPedido;
            if(!DateTime.TryParseExact(tbData.Text, "dd/MM/yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out dataPedido)){
                MessageBox.Show("A data deve estar no formato DD/MM/AAAA HH:MM");
                tbData.Text = "";
            }
        }

        //data do pedido
        private void tbData_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void cbUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
