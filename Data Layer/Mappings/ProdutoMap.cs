using Domain_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Layer.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder <Produto> builder) 
        {
            builder.ToTable("PRODUTOS");

            builder.HasKey(produto => produto.IdProduto);

            builder.Property(produto => produto.IdProduto).HasColumnName("ID").ValueGeneratedNever();

            builder.Property(produto => produto.Nome).HasColumnName("NOME").HasColumnType("VARCHAR(150)").HasMaxLength(150).IsRequired();

            builder.Property(produto => produto.Preco).HasColumnName("PRECO").HasColumnType("decimal(10, 2)").IsRequired();

            builder.Property(produto => produto.Quantidade).HasColumnName("QUANTIDADE").IsRequired();

            builder.Property(produto => produto.DataHoraCadastro).HasColumnName("DATAHORACADASTRO").IsRequired();
        }
    }
}
