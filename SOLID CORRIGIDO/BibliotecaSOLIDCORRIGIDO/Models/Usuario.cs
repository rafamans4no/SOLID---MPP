namespace Biblioteca.Models
{
    // SRP: dados do usuário estavam misturados dentro de Livro (EmailUsuario, NomeUsuario).
    // Extraídos para sua própria classe, pois representam uma responsabilidade distinta.
    public class Usuario
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Tipo { get; set; }
    }
}
