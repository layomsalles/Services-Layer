namespace Services_Layer.Dtos
{
    public record ProdutoRequest(
        string nome,
        decimal preco,
        int quantidade
    );
}
