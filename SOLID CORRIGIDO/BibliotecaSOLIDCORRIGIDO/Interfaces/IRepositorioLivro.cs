using System.Collections.Generic;

namespace Biblioteca.Interfaces
{
    // DIP: abstração de persistência. GerenciadorAcervo depende desta interface,
    // não de BancoDadosMySQL diretamente. Permite trocar a implementação sem
    // alterar nenhuma classe consumidora.
    public interface IRepositorioLivro
    {
        void Salvar(string tabela, string dados);
        List<string> Buscar(string tabela, string filtro);
    }
}
