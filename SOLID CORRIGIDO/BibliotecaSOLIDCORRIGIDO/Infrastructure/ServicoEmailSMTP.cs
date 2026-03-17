using System;
using Biblioteca.Interfaces;

namespace Biblioteca.Infrastructure
{
    // DIP: ServicoEmailSMTP agora implementa IServicoEmail.
    // GerenciadorAcervo depende da interface, não desta classe diretamente.
    // Para trocar de provedor, basta criar outra implementação de IServicoEmail.
    public class ServicoEmailSMTP : IServicoEmail
    {
        public void Enviar(string para, string assunto, string corpo)
        {
            Console.WriteLine($"[SMTP] Para: {para} | Assunto: {assunto} | Corpo: {corpo}");
        }
    }
}
