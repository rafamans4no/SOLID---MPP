using System;
using System.Collections.Generic;
using Biblioteca.Acervo;
using Biblioteca.Descontos;
using Biblioteca.Gerenciamento;
using Biblioteca.Infrastructure;
using Biblioteca.Interfaces;
using Biblioteca.Models;
using Biblioteca.Relatorios;
using Biblioteca.Services;

namespace Biblioteca
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Biblioteca ===\n");

            // DIP: implementacoes concretas definidas aqui, no ponto de composicao.
            // Para trocar banco ou e-mail, basta alterar estas linhas nenhuma outra classe muda.
            IRepositorioLivro banco = new BancoDadosMySQL();
            IServicoEmail email = new ServicoEmailSMTP();

            // SRP: CalculadoraMulta e responsavel exclusivamente pelo calculo de multas
            var calculadora = new CalculadoraMulta();

            // DIP: ServicoEmprestimo recebe suas dependencias via construtor
            var servico = new ServicoEmprestimo(calculadora, banco, email);

            // SRP: Livro e apenas modelo de dados sem logica de negocio
            var livro = new Livro
            {
                Id = 1,
                Titulo = "Clean Code",
                Autor = "Robert C. Martin",
                Genero = "Tecnologia",
                Disponivel = true
            };

            // SRP: dados do usuario agora estao em sua propria classe (separados de Livro)
            var usuario = new Usuario
            {
                Nome = "Joao Silva",
                Email = "aluno@faculdade.edu",
                Tipo = "Estudante"
            };

            servico.RealizarEmprestimo(livro, usuario);

            // Simulando atraso de 20 dias (6 dias de multa = R$ 15,00)
            livro.DataEmprestimo = DateTime.Now.AddDays(-20);

            // OCP: estrategia de desconto injetada sem if/else em ServicoEmprestimo.
            // Para adicionar novo tipo de usuario, crie uma nova classe de desconto.
            IEstrategiaDesconto estrategia = new DescontoEstudante();
            servico.DevolverLivro(livro, usuario, estrategia);

            // SRP: geracao de relatorio de livro e responsabilidade de GeradorRelatorioLivro
            var gerador = new GeradorRelatorioLivro(calculadora);
            livro.Disponivel = false;
            livro.DataEmprestimo = DateTime.Now.AddDays(-20);
            Console.WriteLine("\n--- Relatorio do Livro ---");
            Console.WriteLine(gerador.GerarRelatorio(livro));

            Console.WriteLine("\n--- Polimorfismo (LSP corrigido) ---");
            var itens = new List<ItemAcervo>
            {
                new LivroFisico { Titulo = "Design Patterns", Disponivel = true },
                new EbookEmprestavel { Titulo = "Refactoring", Disponivel = true }
            };

            foreach (var item in itens)
            {
                item.Emprestar("Maria Souza");

                // LSP: reserva e chamada apenas para quem realmente suporta IReservavel.
                // Nao ha mais excecao o contrato de ItemAcervo nunca e quebrado.
                if (item is IReservavel reservavel)
                    reservavel.ReservarItem("Carlos");
                else
                    Console.WriteLine($"[INFO] '{item.Titulo}' nao suporta reserva fisica.");
            }

            Console.WriteLine("\n--- Relatorios (ISP corrigido) ---");
            // ISP: RelatorioEmprestimos so implementa IGerarPDF, IEnviarEmail, ISalvarDisco
            var relEmp = new RelatorioEmprestimos();
            relEmp.GerarRelatorioPDF();
            relEmp.EnviarPorEmail("gestor@biblioteca.edu");
            relEmp.SalvarEmDisco("C:/relatorios/emprestimos.pdf");

            // ISP: RelatorioInventario so implementa IGerarExcel, ISalvarDisco
            var relInv = new RelatorioInventario();
            relInv.GerarRelatorioExcel();
            relInv.SalvarEmDisco("C:/relatorios/inventario.xlsx");

            Console.WriteLine("\n--- Gerenciador (DIP corrigido) ---");
            // DIP: GerenciadorAcervo recebe IRepositorioLivro e IServicoEmail sem new interno
            var gerenciador = new GerenciadorAcervo(banco, email);
            gerenciador.CadastrarLivro(livro);
            gerenciador.NotificarAtraso(usuario.Email, livro.Titulo, 15.00m);

            var livrosDisponiveis = gerenciador.BuscarLivrosDisponiveis();
            Console.WriteLine($"\nLivros disponiveis encontrados: {livrosDisponiveis.Count}");
        }
    }
}
