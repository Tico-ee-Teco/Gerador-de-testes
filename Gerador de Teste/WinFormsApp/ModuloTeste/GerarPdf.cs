using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using WinFormsApp.ModuloQuestao;


namespace WinFormsApp.ModuloTeste
{
    public class GerarPdf
    {       
        public void GerarPdfTeste(Teste teste, string caminho)
        {
            PdfDocument documento = new PdfDocument();
            documento.Info.Title = teste.Titulo;

            PdfPage pagina = documento.AddPage();
            pagina.Size = PageSize.A4;

            XGraphics gfx = XGraphics.FromPdfPage(pagina);
            XFont fonteTitulo = new XFont("Verdana", 20, XFontStyleEx.Bold);
            XFont fonteCabecalho = new XFont("Verdana", 14, XFontStyleEx.Bold);
            XFont fonteQuestao = new XFont("Verdana", 12, XFontStyleEx.Regular);

            double yPoint = 40;

            gfx.DrawString(teste.Titulo, fonteTitulo, XBrushes.Black, new XRect(0, yPoint, pagina.Width, pagina.Height), XStringFormats.TopCenter);
            yPoint += 40;

            gfx.DrawString($"Disciplina: {teste.Disciplina.Nome}", fonteCabecalho, XBrushes.Black, new XRect(40, yPoint, pagina.Width, pagina.Height), XStringFormats.TopLeft);
            yPoint += 30;
            gfx.DrawString($"Matéria: {teste.Materia.Nome}", fonteCabecalho, XBrushes.Black, new XRect(40, yPoint, pagina.Width, pagina.Height), XStringFormats.TopLeft);
            yPoint += 30;

            foreach (var questao in teste.Questoes)
            {
                if (yPoint > pagina.Height - 100)
                {
                    pagina = documento.AddPage();
                    pagina.Size = PageSize.A4;
                    gfx = XGraphics.FromPdfPage(pagina);
                    yPoint = 40;
                }

                gfx.DrawString(questao.Enunciado, fonteQuestao, XBrushes.Black, new XRect(40, yPoint, pagina.Width - 80, pagina.Height), XStringFormats.TopLeft);
                yPoint += 20;

                foreach (var alternativa in questao.Alternativas)
                {
                    gfx.DrawString($"{alternativa.Letra}) {alternativa.TextoAlternativa}", fonteQuestao, XBrushes.Black, new XRect(60, yPoint, pagina.Width - 80, pagina.Height), XStringFormats.TopLeft);
                    yPoint += 20;
                }
                yPoint += 20;
            }

            documento.Save(caminho);

            //PdfDocument document = new PdfDocument();
            //document.Info.Title = "Teste: " + teste.Titulo;

            //PdfPage page = document.AddPage();
            //page.Size = PageSize.A4;
            //XGraphics gfx = XGraphics.FromPdfPage(page);
            //XFont titleFont = new XFont("Verdana", 16, XFontStyleEx.Bold);//, XFontStyle.Bold
            //XFont normalFont = new XFont("Verdana", 12);//, XFontStyle.Regular

            //double yPos = 20;
            //gfx.DrawString(teste.Titulo, titleFont, XBrushes.Black, new XRect(20, yPos, page.Width - 40, 30), XStringFormats.TopCenter);
            //yPos += 40;

            //gfx.DrawString("Disciplina: " + teste.Disciplina, normalFont, XBrushes.Black, new XRect(20, yPos, page.Width - 40, 20), XStringFormats.TopLeft);
            //yPos += 20;

            //gfx.DrawString("Matéria: " + teste.Materia, normalFont, XBrushes.Black, new XRect(20, yPos, page.Width - 40, 20), XStringFormats.TopLeft);
            //yPos += 20;

            //for (int i = 0; i < teste.Questoes.Count; i++)
            //{
            //    Questao questao = teste.Questoes[i];
            //    gfx.DrawString($"{i + 1}. {questao.Enunciado}", normalFont, XBrushes.Black, new XRect(20, yPos, page.Width - 40, 20), XStringFormats.TopLeft);
            //    yPos += 20;

            //    for (int j = 0; j < questao.Alternativas.Count; j++)
            //    {
            //        gfx.DrawString($"   {((char)('A' + j))}. {questao.Alternativas[j]}", normalFont, XBrushes.Black, new XRect(40, yPos, page.Width - 40, 20), XStringFormats.TopLeft);
            //        yPos += 20;
            //    }

            //    yPos += 10;
            //}

            //document.Save(caminho);
        }

        public void GerarPdfGabarito(Teste teste, string caminho)
        {
            PdfDocument documento = new PdfDocument();
            documento.Info.Title = teste.Titulo;

            PdfPage pagina = documento.AddPage();
            pagina.Size = PageSize.A4;

            XGraphics gfx = XGraphics.FromPdfPage(pagina);
            XFont fonteTitulo = new XFont("Verdana", 20, XFontStyleEx.Bold);
            XFont fonteCabecalho = new XFont("Verdana", 14, XFontStyleEx.Bold);
            XFont fonteQuestao = new XFont("Verdana", 12, XFontStyleEx.Regular);

            double yPoint = 40;

            gfx.DrawString(teste.Titulo, fonteTitulo, XBrushes.Black, new XRect(0, yPoint, pagina.Width, pagina.Height), XStringFormats.TopCenter);
            yPoint += 40;

            gfx.DrawString($"Disciplina: {teste.Disciplina.Nome}", fonteCabecalho, XBrushes.Black, new XRect(40, yPoint, pagina.Width, pagina.Height), XStringFormats.TopLeft);
            yPoint += 30;
            gfx.DrawString($"Matéria: {teste.Materia.Nome}", fonteCabecalho, XBrushes.Black, new XRect(40, yPoint, pagina.Width, pagina.Height), XStringFormats.TopLeft);
            yPoint += 30;

            foreach (var questao in teste.Questoes)
            {
                if (yPoint > pagina.Height - 100)
                {
                    pagina = documento.AddPage();
                    pagina.Size = PageSize.A4;
                    gfx = XGraphics.FromPdfPage(pagina);
                    yPoint = 40;
                }

                gfx.DrawString(questao.Enunciado, fonteQuestao, XBrushes.Black, new XRect(40, yPoint, pagina.Width - 80, pagina.Height), XStringFormats.TopLeft);
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
            }

            documento.Save(caminho);

            //PdfDocument document = new PdfDocument();
            //document.Info.Title = teste.Titulo;

            //PdfPage page = document.AddPage();
            //XGraphics gfx = XGraphics.FromPdfPage(page);
            //XFont titleFont = new XFont("Verdana", 20);//, XFontStyle.Bold
            //XFont headerFont = new XFont("Verdana", 14);//, XFontStyle.Bold
            //XFont regularFont = new XFont("Verdana", 12);//, XFontStyle.Regular
            //XFont correctAnswerFont = new XFont("Verdana", 12);//, XFontStyle.Bold

            //int yPoint = 40;

            //gfx.DrawString(teste.Titulo, titleFont, XBrushes.Black, new XRect(0, yPoint, page.Width, page.Height), XStringFormats.TopCenter);
            //yPoint += 40;

            //gfx.DrawString($"Disciplina: {teste.Disciplina}", headerFont, XBrushes.Black, new XRect(40, yPoint, page.Width, page.Height), XStringFormats.TopLeft);
            //yPoint += 30;

            //gfx.DrawString($"Matéria: {teste.Materia.Nome}", headerFont, XBrushes.Black, new XRect(40, yPoint, page.Width, page.Height), XStringFormats.TopLeft);
            //yPoint += 30;

            //for (int i = 0; i < teste.Questoes.Count; i++)
            //{
            //    var questao = teste.Questoes[i];
            //    gfx.DrawString($"{i + 1}. {questao.Enunciado}", regularFont, XBrushes.Black, new XRect(40, yPoint, page.Width, page.Height), XStringFormats.TopLeft);
            //    yPoint += 25;

            //    for (int j = 0; j < questao.Alternativas.Count; j++)
            //    {
            //        bool isCorrect = questao.Alternativas[j].AlternativaCorreta;
            //        gfx.DrawString($"{(char)('A' + j)}. {questao.Alternativas[j].TextoAlternativa}", isCorrect ? correctAnswerFont : regularFont, isCorrect ? XBrushes.Green : XBrushes.Black, new XRect(60, yPoint, page.Width, page.Height), XStringFormats.TopLeft);
            //        yPoint += 20;
            //    }

            //    yPoint += 10;
            //}

            //document.Save(caminho);
        }
    }
}
