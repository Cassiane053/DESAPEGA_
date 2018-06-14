﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desapega.Negocio
{
    public class Troca
    {
        public long Id { get; set; }
        public DateTime Data { get; set; }
        public Usuario Usuario { get; set; }
        public bool Encerrado { get; set; }


        // public List<Lanche> Lanches { get; set; }
        public List<Produto> Produtos { get; set; }

        public Troca()
        {
            this.Data = DateTime.Now;
            this.Encerrado = false;
            //this.Lanches = new List<Lanche>();
            this.Produtos = new List<Produto>();
        }

        //public Decimal Total
        //{
        //get
        //{
        /*Decimal totalLanches = 0;
        foreach(Lanche lanche in Lanches)
        {
            totalLanches += lanche.Valor;
        }*/

        //Decimal totalProdutos = 0;
        //foreach(Produto produto in Produtos)
        // {
        //    totalProdutos += produto.Valor;
        // }

        // Decimal valorTotal = totalLanches + totalBebidas;
        // return valorTotal;
        //}
        //}

        /*public void AdicionarLanche(Lanche lanche)
        {
            if (this.Encerrado)
                throw new Exception("Pedido finalizado. Não é possível adicionar outro lanche");

            this.Lanches.Add(lanche);
        }*/

        public void AdicionarProduto(Produto produto)
        {
            if (this.Encerrado)
                throw new Exception("Solicitação de troca finalizada. Não é possível adicionar outro produto");

            this.Produtos.Add(produto);
        }

        /*public String GerarNotaFiscal()
        {
            String nf = "";
            nf += "Cliente: " + this.Cliente.CPF + " - " + this.Cliente.Nome + Environment.NewLine;
            nf += "======= LANCHES =======" + Environment.NewLine;
            foreach(Lanche lanche in this.Lanches)
            {
                nf += lanche.Id + " - " + lanche.Nome + " - R$" + lanche.Valor + Environment.NewLine;
            }

            nf += Environment.NewLine;
            nf += "======= BEBIDAS =======" + Environment.NewLine;
            foreach (Bebida bebida in this.Bebidas)
            {
                nf += bebida.Id + " - " + bebida.Nome + " - R$" + bebida.Valor + Environment.NewLine;
            }

            nf += Environment.NewLine;
            nf += Environment.NewLine;

            nf += "Total a pagar: R$" + this.Total;

            return nf;
        }*/
    }
}
