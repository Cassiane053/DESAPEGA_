using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desapega.Negocio
{
    public class Gerenciador
    {
        private Gravador Gravador { get; set; }
        private List<Usuario> Usuarios { get; set; }
        // private List<Lanche> Lanches { get; set; }
        private List<Produto> Produtos { get; set; }
        private List<Troca> Trocas { get; set; }

        public Gerenciador()
        {
            this.Usuarios = new List<Usuario>();
            //this.Lanches = new List<Lanche>();
            this.Produtos = new List<Produto>();
            this.Trocas = new List<Troca>();


            this.Gravador = new Gravador();
            this.Carregar();
        }

        public void Carregar()
        {
            DadosGravador dados = this.Gravador.Carregar();
            this.Usuarios = dados.Usuarios;
            this.Produtos = dados.Produtos;
            //this.Lanches = dados.Lanches;
            this.Trocas = dados.Trocas;
        }

        public void Salvar()
        {
            this.Gravador.Salvar(this.Usuarios,
                                 this.Produtos,
                                 //this.Lanches,
                                 this.Trocas);
        }

        public List<Troca> TrocasCadastradas()
        {
            return this.Trocas.ToList();
        }

        public List<Usuario> UsuariosCadastrados()
        {
            return this.Usuarios.ToList();
        }

        public List<Produto> ProdutosCadastrados()
        {
            return this.Produtos.ToList();
        }

        /* public List<Lanche> LanchesCadastrados()
         {
             return this.Lanches.ToList();
         }*/

        public Produto BuscarProdutoPorCodigo(long idProduto)
        {
            return this.Produtos
                       .Where(produto => produto.Id == idProduto)
                       .FirstOrDefault();
        }

        public void RemoverProdutoPorCodigo(long idProduto)
        {
            this.Produtos.Remove(this.Produtos
                       .Where(produto => produto.Id == idProduto)
                       .FirstOrDefault());
            Salvar();
        }

        /*public Lanche BuscarLanchePorCodigo(long codigoLanche)
        {
            return this.Lanches
                       .Where(lanche => lanche.Id == codigoLanche)
                       .FirstOrDefault();
        }

        public void RemoverLanchePorCodigo(long codigoLanche)
        {
            this.Lanches.Remove(this.Lanches
                       .Where(lanche => lanche.Id == codigoLanche)
                       .FirstOrDefault());
            Salvar();
        }*/

        public Usuario BuscarUsuarioPorCPF(String cpf)
        {
            return this.Usuarios.Where(usuario => usuario.CPF.Equals(cpf)).FirstOrDefault();
        }

        public Troca BuscarTrocaPorCodigo(long codigoTroca)
        {
            return this.Trocas.Where(troca => troca.Id == codigoTroca).FirstOrDefault();
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            if (usuario == null)
                throw new Exception("O usuário não pode ser nulo");

            if (String.IsNullOrEmpty(usuario.CPF))
                throw new Exception("O usuário precisa ter o CPF");

            if (String.IsNullOrEmpty(usuario.Nome))
                throw new Exception("O usuário precisa ter um nome");

            if (String.IsNullOrEmpty(usuario.Email))
                throw new Exception("O usuário precisa ter um email");

            this.Usuarios.Add(usuario);
            this.Salvar();
        }


        /*public void AdicionarLanche(Lanche lanche)
        {
            if (lanche == null)
                throw new Exception("O lanche não pode ser nulo");

            if (String.IsNullOrEmpty(lanche.Nome))
                throw new Exception("Informe o nome do lanche");

            this.Lanches.Add(lanche);
            this.Salvar();
        }*/

        public void AdicionarProduto(Produto produto)
        {
            if (produto == null)
                throw new Exception("O produto não pode ser nulo/vazio.");

            if (String.IsNullOrEmpty(produto.Nome))
                throw new Exception("Informe o nome do produto: ");

            /*if (produto.Valor < 0)
                throw new Exception("O valor não pode ser negativo!");*/

            //if (produto.Tamanho <= 0)
            // throw new Exception("Informe o tamanho da bebida: ");

            this.Produtos.Add(produto);
            this.Salvar();
        }

        public void AdicionarTroca(Troca troca)
        {
            if (troca == null)
                throw new Exception("A troca não pode ser nula.");

            if (troca.Usuario == null)
                throw new Exception("Informe o usuário da troca.");

            if (troca.Data == null || troca.Data == DateTime.MinValue)
                throw new Exception("Informe a data da troca");

            this.Trocas.Add(troca);
            this.Salvar();
        }

        public void AdicionarProdutoATroca(Troca troca, Produto produto)
        {
            troca.AdicionarProduto(produto);
            this.Salvar();
        }

        /*public void AdicionarLancheAoPedido(Pedido pedido, Lanche lanche)
        {
            pedido.AdicionarLanche(lanche);
            this.Salvar();
        }*/

        public void RemoverProdutoDaTroca(Troca troca, long idTroca)
        {
            troca.Produtos.Remove(troca.Produtos.FirstOrDefault(e => e.Id.Equals(idTroca)));
            Salvar();
        }

        /*public void RemoverLancheDoPedido(Pedido pedido, long idLanche)
        {
            pedido.Lanches.Remove(pedido.Lanches.FirstOrDefault(e => e.Id.Equals(idLanche)));
            Salvar();
        }*/

        //remover usuário
        public void RemoverUsuario(string CPF)
        {
            this.Usuarios.Remove(this.Usuarios.Where(usuario => (usuario.CPF) == CPF).FirstOrDefault());
        }

        public String GerarRelatorioGeral()
        {
            String relatorio = "";
            relatorio += "=========== RELATÓRIO ===========" + Environment.NewLine;
            foreach (var usuario in this.Usuarios)
            {
                relatorio += "Nome: " + usuario.Nome + Environment.NewLine;
                List<Troca> trocasUsuario = this.Trocas
                                                  .Where(troca => troca.Usuario.CPF == usuario.CPF)
                                                  .Where(troca => troca.Encerrado == true)
                                                  .ToList();

                if (trocasUsuario.Count == 0)
                {
                    relatorio += "Este usuário não tem nenhuma solicitação de troca." + Environment.NewLine;
                    continue;
                }

                Int32 quantidadeProdutos = 0;
                //Decimal totalGeral = 0;
                foreach (var troca in trocasUsuario)
                {
                    quantidadeProdutos += troca.Produtos.Count;
                    //totalGeral += troca.Total;
                }

                relatorio += quantidadeProdutos + " produtos " + Environment.NewLine;

                relatorio += "----------------------------------------" + Environment.NewLine;

            }

            return relatorio;
        }


    }
}
