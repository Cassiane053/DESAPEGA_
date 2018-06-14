using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Desapega.Negocio
{
    public class Gravador
    {

        private String NomeArquivo = "dados.xml";

        public void Salvar(List<Usuario> usuarios,
                           List<Produto> produtos,
                           //List<Lanche> lanches,
                           List<Troca> trocas)
        {
            DadosGravador dados = new DadosGravador();
            dados.Usuarios = usuarios;
            dados.Produtos = produtos;
            //dados.Lanches = lanches;
            dados.Trocas = trocas;

            StreamWriter arquivo = new StreamWriter(NomeArquivo);
            XmlSerializer serializer = new XmlSerializer(typeof(DadosGravador));
            serializer.Serialize(arquivo, dados);
            arquivo.Close();
        }

        public DadosGravador Carregar()
        {
            DadosGravador dados = new DadosGravador();

            if (File.Exists(NomeArquivo))
            {
                StreamReader arquivo = new StreamReader(NomeArquivo);
                XmlSerializer serializer = new XmlSerializer(typeof(DadosGravador));
                dados = serializer.Deserialize(arquivo) as DadosGravador;
                arquivo.Close();
            }
            return dados;

        }
    }
}
