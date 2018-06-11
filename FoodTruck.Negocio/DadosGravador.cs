using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desapega.Negocio
{
    public class DadosGravador
    {
        public List<Usuario> Usuarios { get; set; }
        //public List<Lanche> Lanches { get; set; }
        public List<Produto> Produtos { get; set; }
        public List<Troca> Trocas { get; set; }

        public DadosGravador()
        {   //criacao das listas
            this.Usuarios = new List<Usuario>();
            //this.Lanches = new List<Lanche>();
            this.Produtos = new List<Produto>();
            this.Trocas = new List<Troca>();
        }
    }
}
