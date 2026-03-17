using Biblioteca.Interfaces;

namespace Biblioteca.Descontos
{
    // OCP: cada tipo de usuário tem sua própria classe de desconto.
    // Para adicionar um novo tipo (ex: "Idoso", "VIP"), basta criar
    // uma nova classe aqui sem modificar ServicoEmprestimo.

    public class DescontoEstudante : IEstrategiaDesconto
    {
        public decimal AplicarDesconto(decimal valorMulta) => valorMulta * 0.50m;
    }

    public class DescontoProfessor : IEstrategiaDesconto
    {
        public decimal AplicarDesconto(decimal valorMulta) => valorMulta * 0.80m;
    }

    public class DescontoFuncionario : IEstrategiaDesconto
    {
        public decimal AplicarDesconto(decimal valorMulta) => valorMulta * 0.30m;
    }

    public class SemDesconto : IEstrategiaDesconto
    {
        public decimal AplicarDesconto(decimal valorMulta) => 0m;
    }
}
