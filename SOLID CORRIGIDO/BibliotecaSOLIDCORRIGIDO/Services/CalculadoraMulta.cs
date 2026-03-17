using System;
using Biblioteca.Models;

namespace Biblioteca.Services
{
    // SRP: cálculo de multa era responsabilidade da classe Livro.
    // Extraído para cá pois é uma regra de negócio independente.
    public class CalculadoraMulta
    {
        public decimal Calcular(Livro livro)
        {
            if (livro.DataEmprestimo == null) return 0;
            var diasAtraso = (DateTime.Now - livro.DataEmprestimo.Value).Days - 14;
            if (diasAtraso <= 0) return 0;
            return diasAtraso * 2.50m;
        }
    }
}
