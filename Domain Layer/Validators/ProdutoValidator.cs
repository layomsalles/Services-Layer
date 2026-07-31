using Domain_Layer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain_Layer.Validators
{
    public class ProdutoValidator: AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(produto => produto.Nome).NotEmpty().WithMessage("Product name is required").MinimumLength(3).WithMessage("Product name must have at least 3 characters").MaximumLength(150).WithMessage("Product name must have at most 150 characters");

            RuleFor(produto => produto.Preco).GreaterThanOrEqualTo(0).WithMessage("Product price must be a greater or equal to zero");

            RuleFor(produto => produto.Quantidade).GreaterThanOrEqualTo(0).WithMessage("Product quantity must be greater or equal to zero");
        }
        
    }
}
