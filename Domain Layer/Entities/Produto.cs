using System;
using System.Collections.Generic;
using System.Text;

namespace Domain_Layer.Entities
{
    public class Produto
    {
        public Guid IdProduto { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; } = 0;
        public int Quantidade { get; set; } = 0;
        public DateTime DataHoraCadastro { get; set; } = DateTime.Now;
    }
}
