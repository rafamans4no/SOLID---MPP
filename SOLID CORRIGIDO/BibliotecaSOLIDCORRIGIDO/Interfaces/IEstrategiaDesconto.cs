namespace Biblioteca.Interfaces
{
    // OCP: abstração que permite adicionar novos tipos de desconto
    // sem modificar ServicoEmprestimo. Basta criar uma nova classe
    // que implemente esta interface.
    public interface IEstrategiaDesconto
    {
        decimal AplicarDesconto(decimal valorMulta);
    }
}
