using Data_Layer.Contexts;
using Domain_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Layer.Repositories
{
    public class ProdutoRepository
    {
        private readonly DataContext _context;

        public ProdutoRepository(DataContext context)
        {
            _context = context;
        }
        public void AddProdutc(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public void UpdateProduct(Produto produto)
        {
            _context.Produtos.Update(produto);
            _context.SaveChanges();
        }

        public void DeleteProduct(Produto produto)
        {
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
        }

        public List<Produto> GetProduct()
        {
            return _context.Produtos.AsNoTracking().OrderByDescending(produto => produto.DataHoraCadastro).ToList();
        }

        public Produto? GetById(Guid id)
        {
            return _context.Produtos.AsNoTracking().FirstOrDefault(produto => produto.IdProduto == id);
        }
    }
}
