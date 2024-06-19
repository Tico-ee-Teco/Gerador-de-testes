using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace WinFormsApp.ModuloTeste
{
    public class GerarPdf
    {
        public void GerarPdfTeste(Teste teste, string caminho)
        {
            PdfDocument documento = new PdfDocument();
            documento.Info.Title = teste.Titulo;

            XFont fonteTitulo = new XFont("Verdana", 20, XFontStyleEx.Bold);
            XFont fonteCabecalho = new XFont("Verdana", 14, XFontStyleEx.Bold);
            XFont fonteQuestao = new XFont("Verdana", 12, XFontStyleEx.Regular);
            XFont fonteRodape = new XFont("Verdana", 10, XFontStyleEx.Regular);

            int numeroPagina = 1;
            double margemInferior = 40;

            PdfPage pagina = documento.AddPage();
            pagina.Size = PageSize.A4;

            XGraphics gfx = XGraphics.FromPdfPage(pagina);

            double yPoint = 40;

            gfx.DrawString(teste.Titulo, fonteTitulo, XBrushes.Black, new XRect(0, yPoint, pagina.Width, pagina.Height), XStringFormats.TopCenter);
            yPoint += 40;

            gfx.DrawString($"Disciplina: {teste.Disciplina.Nome}", fonteCabecalho, XBrushes.Black, new XRect(40, yPoint, pagina.Width, pagina.Height), XStringFormats.TopLeft);
            yPoint += 30;           
            
            if(teste.Materia != null)
            {
                gfx.DrawString($"Matéria: {teste.Materia.Nome}", fonteCabecalho, XBrushes.Black, new XRect(40, yPoint, pagina.Width, pagina.Height), XStringFormats.TopLeft);            
                yPoint += 30;
            }
            else
            {
                gfx.DrawString($"Matéria: Prova de Recuperação", fonteCabecalho, XBrushes.Black, new XRect(40, yPoint, pagina.Width, pagina.Height), XStringFormats.TopLeft);
                yPoint += 30;
            }

            int numeroQuestao = 1;
            int questoesPorPagina = 5; 
            bool primeiraPagina = true;

            foreach (var questao in teste.Questoes)
            {
                if (!primeiraPagina && numeroQuestao % 5 == 1)
                {
                    gfx.DrawString($"Página {numeroPagina}", fonteRodape, XBrushes.Black, new XRect(0, pagina.Height - margemInferior, pagina.Width - 40, fonteRodape.Height), XStringFormats.BottomRight);
                    numeroPagina++;

                    pagina = documento.AddPage();
                    pagina.Size = PageSize.A4;
                    gfx = XGraphics.FromPdfPage(pagina);
                    yPoint = 40;

                    questoesPorPagina = 6;
                }

                if (primeiraPagina || numeroQuestao <= 5)
                {
                    gfx.DrawString($"{numeroQuestao} - {questao.Enunciado}", fonteQuestao, XBrushes.Black, new XRect(40, yPoint, pagina.Width - 80, pagina.Height), XStringFormats.TopLeft);
                    yPoint += 20;

                    foreach (var alternativa in questao.Alternativas)
                    {
                        gfx.DrawString($"{alternativa.Letra}) {alternativa.TextoAlternativa}", fonteQuestao, XBrushes.Black, new XRect(60, yPoint, pagina.Width - 80, pagina.Height), XStringFormats.TopLeft);
                        yPoint += 20;
                    }
                    yPoint += 20;
                }
                else
                {
                    gfx.DrawString($"{numeroQuestao} - {questao.Enunciado}", fonteQuestao, XBrushes.Black, new XRect(40, yPoint, pagina.Width - 80, pagina.Height), XStringFormats.TopLeft);
                    yPoint += 20;

                    foreach (var alternativa in questao.Alternativas)
                    {
                        gfx.DrawString($"{alternativa.Letra}) {alternativa.TextoAlternativa}", fonteQuestao, XBrushes.Black, new XRect(60, yPoint, pagina.Width - 80, pagina.Height), XStringFormats.TopLeft);
                        yPoint += 20;
                    }
                    yPoint += 20;
                }

                if (primeiraPagina && numeroQuestao == 5)
                {
                    questoesPorPagina = 6;
                    primeiraPagina = false;
                }

                numeroQuestao++;
            }

            // Desenha o número da última página
            gfx.DrawString($"Página {numeroPagina}", fonteRodape, XBrushes.Black, new XRect(0, pagina.Height - margemInferior, pagina.Width - 40, fonteRodape.Height), XStringFormats.BottomRight);

            documento.Save(caminho);           
        }

        public void GerarPdfGabarito(Teste teste, string caminho)
        {

            PdfDocument documento = new PdfDocument();
            documento.Info.Title = "Gabarito - " + teste.Titulo;

            XFont fonteTitulo = new XFont("Verdana", 20, XFontStyleEx.Bold);
            XFont fonteCabecalho = new XFont("Verdana", 14, XFontStyleEx.Bold);
            XFont fonteQuestao = new XFont("Verdana", 12, XFontStyleEx.Regular);
            XFont fonteRodape = new XFont("Verdana", 10, XFontStyleEx.Regular);

            int numeroPagina = 1;
            double margemInferior = 40;

            int questoesPorPagina = 0;

            PdfPage pagina = documento.AddPage();
            pagina.Size = PageSize.A4;
            XGraphics gfx = XGraphics.FromPdfPage(pagina);

            double yPoint = 40;

            gfx.DrawString($"Gabarito - {teste.Titulo}", fonteTitulo, XBrushes.Black, new XRect(0, yPoint, pagina.Width, pagina.Height), XStringFormats.TopCenter);
            yPoint += 40;

            gfx.DrawString($"Disciplina: {teste.Disciplina.Nome}", fonteCabecalho, XBrushes.Black, new XRect(40, yPoint, pagina.Width, pagina.Height), XStringFormats.TopLeft);
            yPoint += 30;
            if(teste.Materia != null)
            {
                gfx.DrawString($"Matéria: {teste.Materia.Nome}", fonteCabecalho, XBrushes.Black, new XRect(40, yPoint, pagina.Width, pagina.Height), XStringFormats.TopLeft);
                yPoint += 30;
            }
            else
            {
                gfx.DrawString($"Matéria: Prova de Recuperação", fonteCabecalho, XBrushes.Black, new XRect(40, yPoint, pagina.Width, pagina.Height), XStringFormats.TopLeft);
                yPoint += 30;
            }

            int numeroQuestao = 1;

            foreach (var questao in teste.Questoes)
            {
                if ((numeroQuestao > 5 && questoesPorPagina == 0) || questoesPorPagina == 6)
                {
                    gfx.DrawString($"Página {numeroPagina}", fonteRodape, XBrushes.Black, new XRect(0, pagina.Height - margemInferior, pagina.Width - 40, fonteRodape.Height), XStringFormats.BottomRight);
                    numeroPagina++;

                    pagina = documento.AddPage();
                    pagina.Size = PageSize.A4;
                    gfx = XGraphics.FromPdfPage(pagina);
                    yPoint = 40;

                    questoesPorPagina = 0;
                }

                gfx.DrawString($"{numeroQuestao} - {questao.Enunciado}", fonteQuestao, XBrushes.Black, new XRect(40, yPoint, pagina.Width - 80, pagina.Height), XStringFormats.TopLeft);
                yPoint += 20;

                foreach (var alternativa in questao.Alternativas)
                {
                    if (alternativa.AlternativaCorreta)
                    {
                        gfx.DrawString($"{alternativa.Letra}) {alternativa.TextoAlternativa}", fonteQuestao, XBrushes.Green, new XRect(60, yPoint, pagina.Width - 80, pagina.Height), XStringFormats.TopLeft);
                    }
                    else
                    {
                        gfx.DrawString($"{alternativa.Letra}) {alternativa.TextoAlternativa}", fonteQuestao, XBrushes.Black, new XRect(60, yPoint, pagina.Width - 80, pagina.Height), XStringFormats.TopLeft);
                    }
                    yPoint += 20;
                }
                yPoint += 20;

                numeroQuestao++;
                questoesPorPagina++;
                
                if (numeroQuestao == 6)
                {
                    questoesPorPagina = 0;
                }
            }

            // Desenha o número da última página
            gfx.DrawString($"Página {numeroPagina}", fonteRodape, XBrushes.Black, new XRect(0, pagina.Height - margemInferior, pagina.Width - 40, fonteRodape.Height), XStringFormats.BottomRight);

            documento.Save(caminho);
        }       
    }
}
