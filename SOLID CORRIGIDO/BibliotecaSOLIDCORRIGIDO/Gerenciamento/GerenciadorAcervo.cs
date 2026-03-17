using System;
using System.Collections.Generic;
using Biblioteca.Interfaces;
using Biblioteca.Models;

namespace Biblioteca.Gerenciamento
{
    // DIP: GerenciadorAcervo não instancia mais BancoDadosMySQL nem ServicoEmailSMTP diretamente.
    // As dependências são recebidas pelo construtor (injeção de dependência),
    // permitindo trocar implementações sem modificar esta classe.
    public class GerenciadorAcervo
    {
        private readonly IRepositorioLivro _banco;
        private readonly IServicoEmail _email;

        public GerenciadorAcervo(IRepositorioLivro banco, IServicoEmail email)
        {
            _banco = banco;
            _email = email;
        }

        public void CadastrarLivro(Livro livro)
        {
            _banco.Salvar("livros", $"'{livro.Titulo}', '{livro.Autor}'");
            Console.WriteLine($"Livro '{livro.Titulo}' cadastrado.");
        }

        public void NotificarAtraso(string emailUsuario, string tituloLivro, decimal multa)
        {
            _email.Enviar(emailUsuario, "Atraso na devolução",
                $"Você tem uma multa de R${multa} pelo livro '{tituloLivro}'.");
        }

        public List<string> BuscarLivrosDisponiveis()
        {
            return _banco.Buscar("livros", "disponivel = true");
        }
    }
}
