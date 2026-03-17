using System;
using Biblioteca.Interfaces;

namespace Biblioteca.Relatorios
{
    // ISP: RelatorioEmprestimos implementa apenas as interfaces que realmente usa.
    // No original era forçado a implementar GerarRelatorioExcel e GerarRelatorioHTML
    public class RelatorioEmprestimos : IGerarPDF, IEnviarEmail, ISalvarDisco
    {
        public void GerarRelatorioPDF()
        {
            Console.WriteLine("Gerando PDF de empréstimos...");
        }

        public void EnviarPorEmail(string destinatario)
        {
            Console.WriteLine($"Enviando relatório de empréstimos para {destinatario}");
        }

        public void SalvarEmDisco(string caminho)
        {
            Console.WriteLine($"Salvando relatório em {caminho}");
        }
    }

    // ISP: RelatorioInventario implementa apenas as interfaces que realmente usa.
    // No original era forçado a implementar PDF, HTML e EnviarPorEmail
    public class RelatorioInventario : IGerarExcel, ISalvarDisco
    {
        public void GerarRelatorioExcel()
        {
            Console.WriteLine("Gerando Excel de inventário...");
        }

        public void SalvarEmDisco(string caminho)
        {
            Console.WriteLine($"Salvando inventário em {caminho}");
        }
    }
}
