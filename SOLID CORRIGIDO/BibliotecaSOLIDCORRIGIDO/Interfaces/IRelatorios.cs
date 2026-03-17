namespace Biblioteca.Interfaces
{
    // ISP: a interface IRelatorio original era grande e obrigava todas as classes
    // a implementar métodos que não usavam, lançando NotImplementedException.
    // Solução: dividir em interfaces menores e coesas. Cada classe implementa
    // apenas o que realmente precisa.

    // ISP: interface para geração de PDF
    public interface IGerarPDF
    {
        void GerarRelatorioPDF();
    }

    // ISP: interface para geração de Excel
    public interface IGerarExcel
    {
        void GerarRelatorioExcel();
    }

    // ISP: interface para geração de HTML
    public interface IGerarHTML
    {
        void GerarRelatorioHTML();
    }

    // ISP: interface para envio por e-mail
    public interface IEnviarEmail
    {
        void EnviarPorEmail(string destinatario);
    }

    // ISP: interface para salvamento em disco
    public interface ISalvarDisco
    {
        void SalvarEmDisco(string caminho);
    }
}
