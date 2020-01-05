using System;
using System.Data.Entity;

namespace Data
{
    public class DataContext : DbContext
    {
        public DataContext(string connectionString = "Data Source=LAPTOP-81HO7HHK;Initial Catalog=Estoque;Integrated Security=True") : base(connectionString)
        {
            
        }


        public void Delete<T>( T entity)
        {
            Entry(entity).State = EntityState.Deleted;
            base.SaveChanges();
        }


        public DbSet<Produto> Produtos { get; set; }

    }
}
