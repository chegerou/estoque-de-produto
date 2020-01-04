using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataFramework
{
    public class Adicionar
    {
        
        public void AdicionarProduto()
        {
            var db = new DataContext();

            var produto = new Produto()
            {
                Nome = "Arroz",
                Preco = 10,
                Quantidade = 5

            };

            db.Produtos.Add(produto);

            db.SaveChanges();

        }



    }
}
