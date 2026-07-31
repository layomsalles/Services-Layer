using Domain_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Layer.Contexts
{
    //Herdando os recursos do Entity Framework.
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //Representa a tabela de produtos.
        public DbSet<Produto> Produtos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //manda o Entity Framework procurar automaticamente as classes de mapeamento existentes no projeto Data Layer.
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(DataContext).Assembly
                );
        }
    }
}
