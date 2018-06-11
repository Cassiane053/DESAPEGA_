using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desapega.Negocio
{
    public class Produto : Relatorio
    {
        public long Tamanho { get; set; }
        public long Descricao { get; set; }
        public string Categoria { get; set; }


        //mostra na tela as informações do produto
        //public override string Relatorio()
        //{
        //    return Nome + " - " + Descricao;
        //}

    }
}
