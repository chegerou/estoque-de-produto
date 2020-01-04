using Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EstoqueProduto.Model
{
    public class Estoque
    {
        public static List<Produto> BuscarProdutos()
        {
            try
            {
                using (var context = new DataContext())
                {
                    return context.Produtos.Where(produto => produto.Id != 0).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static Produto BuscarProduto(int id)
        {
            try
            {
                using (var context = new DataContext())
                {
                    return context.Produtos.Where(produto => produto.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static Produto AtualizarProduto(Produto modifyProduto)
        {
            try
            {
                using (var context = new DataContext())
                {
                    Produto produto = context.Produtos.Where(produto => produto.Id == modifyProduto.Id).FirstOrDefault();

                    produto.Nome = modifyProduto.Nome;
                    produto.Quantidade = modifyProduto.Quantidade;
                    produto.Preco = modifyProduto.Preco;

                    context.SaveChanges();

                    return produto;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string DeletarProduto(int id)
        {
            try
            {
                using (var context = new DataContext())
                {                   
                    context.Delete(this.GetProduto(id));
                    
                    if(this.GetProduto(id) == null)
                        return "O Produto foi deletado.";
                    else
                        return "Houve um erro ao deletar o produto.";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Produto SalvarProduto(Produto newProduto)
        {
            try
            {
                using (var context = new DataContext())
                {
                    context.Produtos.Add(newProduto);
                    context.SaveChanges();

                    return context.Produtos.Where(produto => produto.Id == newProduto.Id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
