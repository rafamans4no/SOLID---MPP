using System;
using Biblioteca.Interfaces;

namespace Biblioteca.Acervo
{
    // LSP: ReservarItem() foi removido da classe base pois não é suportado por todos os subtipos.
    // Mover para ItemAcervo obrigava EbookEmprestavel a lançar NotSupportedException,
    // quebrando o contrato esperado por qualquer código que use ItemAcervo.
    public abstract class ItemAcervo
    {
        public string Titulo { get; set; }
        public bool Disponivel { get; set; }

        public abstract void Emprestar(string usuario);
        public abstract void Devolver();
    }

    // LSP: LivroFisico suporta reserva física implementa IReservavel .
    public class LivroFisico : ItemAcervo, IReservavel
    {
        public override void Emprestar(string usuario)
        {
            Disponivel = false;
            Console.WriteLine($"[FÍSICO] '{Titulo}' emprestado para {usuario}.");
        }

        public override void Devolver()
        {
            Disponivel = true;
            Console.WriteLine($"[FÍSICO] '{Titulo}' devolvido.");
        }

        public void ReservarItem(string usuario)
        {
            Console.WriteLine($"[FÍSICO] '{Titulo}' reservado para {usuario} por 3 dias.");
        }
    }

    // LSP: EbookEmprestavel não implementa IReservavel.
    
    public class EbookEmprestavel : ItemAcervo
    {
        public override void Emprestar(string usuario)
        {
            Disponivel = false;
            Console.WriteLine($"[EBOOK] Link de download enviado para {usuario}.");
        }

        public override void Devolver()
        {
            Disponivel = true;
            Console.WriteLine($"[EBOOK] Acesso revogado.");
        }
    }
}
