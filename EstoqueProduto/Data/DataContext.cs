using Data;
using System.Data.Entity;

namespace DataFramework
{
    class DataContext : DbContext
    {
        public DataContext(string connectionString = "Data Source=LAPTOP-81HO7HHK;Initial Catalog=Estoque;Integrated Security=True") : base(connectionString)
        {
            
        }

        public DbSet<Produto> Produtos { get; set; }
    }
}
