namespace Biblioteca.Interfaces
{
    // LSP: reserva física foi removida de ItemAcervo e colocada nesta interface.
    // Somente classes que realmente suportam reserva a implementam.
    public interface IReservavel
    {
        void ReservarItem(string usuario);
    }
}
