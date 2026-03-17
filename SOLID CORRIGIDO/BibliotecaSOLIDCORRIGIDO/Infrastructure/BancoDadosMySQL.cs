using System;
using System.Collections.Generic;
using Biblioteca.Interfaces;

namespace Biblioteca.Infrastructure
{
    // DIP: BancoDadosMySQL agora implementa IRepositorioLivro.
    // GerenciadorAcervo depende da interface, não desta classe diretamente.
    // Para trocar de banco, basta criar outra implementação de IRepositorioLivro.
    public class BancoDadosMySQL : IRepositorioLivro
    {
        public void Salvar(string tabela, string dados)
        {
            Console.WriteLine($"[MySQL] INSERT INTO {tabela}: {dados}");
        }

        public List<string> Buscar(string tabela, string filtro)
        {
            Console.WriteLine($"[MySQL] SELECT * FROM {tabela} WHERE {filtro}");
            return new List<string> { "resultado simulado" };
        }
    }
}
