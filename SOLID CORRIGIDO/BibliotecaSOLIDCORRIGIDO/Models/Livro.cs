using System;

namespace Biblioteca.Models
{
    // SRP: Livro agora é apenas um modelo de dados.
    // As responsabilidades de calcular multa, enviar e-mail,
    // persistir e gerar relatório foram movidas para classes próprias.
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public bool Disponivel { get; set; }
        public DateTime? DataEmprestimo { get; set; }
    }
}
