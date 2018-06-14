using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desapega.Negocio
{
    public class Usuario
    {
        public String CPF { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Telefone { get; set; }
        public String DataNasc { get; set; }
        public String TipoUsuario { get; set; }

        //mostra na tela as informações do cliente
        public override string ToString()
        {
            return this.Nome + " - " + this.TipoUsuario;
        }
    }
}
