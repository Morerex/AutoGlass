using Autoglass.Architecture.Domain.Entities;
using Autoglass.Architecture.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Autoglass.Architecture.Infra.Data.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {

        }

        public DbSet<Produto> Produto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>(new ProdutoMap().Configure);
        }
    }
}
