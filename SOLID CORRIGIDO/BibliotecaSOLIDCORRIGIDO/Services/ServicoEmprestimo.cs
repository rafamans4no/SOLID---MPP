using System;
using Biblioteca.Interfaces;
using Biblioteca.Models;
using Biblioteca.Services;

namespace Biblioteca.Services
{
    // OCP: CalcularDesconto foi removido. A estratégia de desconto agora é
    // recebida por parâmetro em DevolverLivro sem if/else por tipo de usuário.
    // DIP: recebe IRepositorioLivro e IServicoEmail via construtor (injeção de dependência).
    public class ServicoEmprestimo
    {
        private readonly CalculadoraMulta _calculadora;
        private readonly IRepositorioLivro _repositorio;
        private readonly IServicoEmail _email;

        public ServicoEmprestimo(CalculadoraMulta calculadora, IRepositorioLivro repositorio, IServicoEmail email)
        {
            _calculadora = calculadora;
            _repositorio = repositorio;
            _email = email;
        }

        public void RealizarEmprestimo(Livro livro, Usuario usuario)
        {
            if (!livro.Disponivel)
            {
                Console.WriteLine("Livro indisponível.");
                return;
            }

            livro.Disponivel = false;
            livro.DataEmprestimo = DateTime.Now;

            // DIP: persiste via abstração, não via classe concreta
            _repositorio.Salvar("livros", $"'{livro.Titulo}', '{livro.Autor}', {livro.Disponivel}");

            Console.WriteLine($"Empréstimo realizado: {livro.Titulo} para {usuario.Nome}");
        }

        public void DevolverLivro(Livro livro, Usuario usuario, IEstrategiaDesconto estrategia)
        {
            var multa = _calculadora.Calcular(livro);

            // OCP: desconto calculado pela estratégia injetada  sem modificar este método
            var desconto = estrategia.AplicarDesconto(multa);
            var multaFinal = multa - desconto;

            livro.Disponivel = true;
            livro.DataEmprestimo = null;

            // DIP: persiste via abstração
            _repositorio.Salvar("livros", $"'{livro.Titulo}', '{livro.Autor}', {livro.Disponivel}");

            if (multaFinal > 0)
            {
                Console.WriteLine($"Devolução com multa de R${multaFinal}");

                // DIP: envia e-mail via abstração
                var conteudo = $"Olá {usuario.Nome}, você tem uma multa de R${multaFinal} pelo livro '{livro.Titulo}'.";
                _email.Enviar(usuario.Email, "Atraso na devolução", conteudo);
            }
            else
            {
                Console.WriteLine("Devolução sem multa. Obrigado!");
            }
        }
    }
}
