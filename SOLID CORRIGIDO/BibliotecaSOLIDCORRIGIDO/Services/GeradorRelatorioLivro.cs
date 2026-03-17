using Biblioteca.Models;

namespace Biblioteca.Services
{
    // SRP: geração de relatório era responsabilidade da classe Livro.
    // Extraído para cá pois é uma responsabilidade de apresentação independente.
    public class GeradorRelatorioLivro
    {
        private readonly CalculadoraMulta _calculadora;

        public GeradorRelatorioLivro(CalculadoraMulta calculadora)
        {
            _calculadora = calculadora;
        }

        public string GerarRelatorio(Livro livro)
        {
            return $"Livro: {livro.Titulo} | Autor: {livro.Autor} | Disponível: {livro.Disponivel} | Multa: R${_calculadora.Calcular(livro)}";
        }
    }
}
