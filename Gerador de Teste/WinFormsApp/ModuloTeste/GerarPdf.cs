using PdfSharp.Drawing;
using PdfSharp.Pdf;
using WinFormsApp.ModuloQuestao;


namespace WinFormsApp.ModuloTeste
{
    public class GerarPdf
    {       
        public void GerarPdfTeste(Teste teste, string caminho)
        {
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Teste: " + teste.Titulo;

            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont titleFont = new XFont("Verdana", 16);//, XFontStyle.Bold
            XFont normalFont = new XFont("Verdana", 12);//, XFontStyle.Regular

            double yPos = 20;
            gfx.DrawString(teste.Titulo, titleFont, XBrushes.Black, new XRect(20, yPos, page.Width - 40, 30), XStringFormats.TopLeft);
            yPos += 40;

            gfx.DrawString("Disciplina: " + teste.Disciplina, normalFont, XBrushes.Black, new XRect(20, yPos, page.Width - 40, 20), XStringFormats.TopLeft);
            yPos += 20;

            gfx.DrawString("Matéria: " + teste.Materia, normalFont, XBrushes.Black, new XRect(20, yPos, page.Width - 40, 20), XStringFormats.TopLeft);
            yPos += 20;

            for (int i = 0; i < teste.Questoes.Count; i++)
            {
                Questao questao = teste.Questoes[i];
                gfx.DrawString($"{i + 1}. {questao.Enunciado}", normalFont, XBrushes.Black, new XRect(20, yPos, page.Width - 40, 20), XStringFormats.TopLeft);
                yPos += 20;

                for (int j = 0; j < questao.Alternativas.Count; j++)
                {
                    gfx.DrawString($"   {((char)('A' + j))}. {questao.Alternativas[j]}", normalFont, XBrushes.Black, new XRect(40, yPos, page.Width - 40, 20), XStringFormats.TopLeft);
                    yPos += 20;
                }

                yPos += 10;
            }

            document.Save(caminho);
        }

        public void GerarPdfGabarito(Teste teste, string caminho)
        {
            PdfDocument document = new PdfDocument();
            document.Info.Title = teste.Titulo;

            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont titleFont = new XFont("Verdana", 20);//, XFontStyle.Bold
            XFont headerFont = new XFont("Verdana", 14);//, XFontStyle.Bold
            XFont regularFont = new XFont("Verdana", 12);//, XFontStyle.Regular
            XFont correctAnswerFont = new XFont("Verdana", 12);//, XFontStyle.Bold

            int yPoint = 40;

            gfx.DrawString(teste.Titulo, titleFont, XBrushes.Black, new XRect(0, yPoint, page.Width, page.Height), XStringFormats.TopCenter);
            yPoint += 40;

            gfx.DrawString($"Disciplina: {teste.Disciplina}", headerFont, XBrushes.Black, new XRect(40, yPoint, page.Width, page.Height), XStringFormats.TopLeft);
            yPoint += 30;

            gfx.DrawString($"Matéria: {teste.Materia.Nome}", headerFont, XBrushes.Black, new XRect(40, yPoint, page.Width, page.Height), XStringFormats.TopLeft);
            yPoint += 30;

            for (int i = 0; i < teste.Questoes.Count; i++)
            {
                var questao = teste.Questoes[i];
                gfx.DrawString($"{i + 1}. {questao.Enunciado}", regularFont, XBrushes.Black, new XRect(40, yPoint, page.Width, page.Height), XStringFormats.TopLeft);
                yPoint += 25;

                for (int j = 0; j < questao.Alternativas.Count; j++)
                {
                    bool isCorrect = questao.Alternativas[j].AlternativaCorreta;
                    gfx.DrawString($"{(char)('A' + j)}. {questao.Alternativas[j].TextoAlternativa}", isCorrect ? correctAnswerFont : regularFont, isCorrect ? XBrushes.Green : XBrushes.Black, new XRect(60, yPoint, page.Width, page.Height), XStringFormats.TopLeft);
                    yPoint += 20;
                }

                yPoint += 10;
            }

            document.Save(caminho);
        }
    }
}
