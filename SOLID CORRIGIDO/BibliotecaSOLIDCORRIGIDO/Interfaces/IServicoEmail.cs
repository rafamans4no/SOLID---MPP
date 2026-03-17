namespace Biblioteca.Interfaces
{
    // DIP: abstração de envio de e-mail. GerenciadorAcervo depende desta interface,
    // não de ServicoEmailSMTP diretamente. Permite trocar a implementação sem
    // alterar nenhuma classe.
    public interface IServicoEmail
    {
        void Enviar(string para, string assunto, string corpo);
    }
}
