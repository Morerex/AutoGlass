using Autoglass.Architecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autoglass.Architecture.Infra.Data.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.CodProduto)
                .IsRequired()
                .HasColumnName("CodProduto")
                .HasColumnType("int");

            builder.Property(prop => prop.DescProduto)
               .HasConversion(prop => prop.ToString(), prop => prop)
               .IsRequired()
               .HasColumnName("DescProduto")
               .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Situacao)
                .IsRequired()
                .HasColumnName("Situacao")
                .HasColumnType("bool");

            builder.Property(prop => prop.DataFabricacao)
                   .IsRequired()
                   .HasColumnName("DataFabricacao")
                   .HasColumnType("DateTime");

            builder.Property(prop => prop.DataValidade)
                .IsRequired()
                .HasColumnName("DataValidade")
                .HasColumnType("DateTime");

            builder.Property(prop => prop.CodFornecedor)
                .IsRequired()
                .HasColumnName("CodFornecedor")
                .HasColumnType("int");

            builder.Property(prop => prop.DescFornecedor)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("DescFornecedor")
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.CnpjFornecedor)
                .IsRequired()
                .HasColumnName("CnpjFornecedor")
                .HasColumnType("int");
        }
    }
}
