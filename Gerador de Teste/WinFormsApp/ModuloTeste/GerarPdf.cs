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

            // Define a posição inicial yPoint
            double yPoint = 40;

            // Desenha o título
            gfx.DrawString(teste.Titulo, fonteTitulo, XBrushes.Black, new XRect(0, yPoint, pagina.Width, pagina.Height), XStringFormats.TopCenter);
            yPoint += 40;

            // Desenha a disciplina e a matéria
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
            int questoesPorPagina = 5; // Inicia com 5 questões na primeira página
            bool primeiraPagina = true;

            foreach (var questao in teste.Questoes)
            {
                // Verifica se yPoint ultrapassou a altura disponível na página
                if (!primeiraPagina && numeroQuestao % 5 == 1)
                {
                    // Desenha o número da página atual
                    gfx.DrawString($"Página {numeroPagina}", fonteRodape, XBrushes.Black, new XRect(0, pagina.Height - margemInferior, pagina.Width - 40, fonteRodape.Height), XStringFormats.BottomRight);
                    numeroPagina++;

                    // Adiciona uma nova página e redefine yPoint
                    pagina = documento.AddPage();
                    pagina.Size = PageSize.A4;
                    gfx = XGraphics.FromPdfPage(pagina);
                    yPoint = 40;

                    // Define o número de questões por página para 6
                    questoesPorPagina = 6;
                }

                if (primeiraPagina || numeroQuestao <= 5)
                {
                    // Desenha a questão
                    gfx.DrawString($"{numeroQuestao} - {questao.Enunciado}", fonteQuestao, XBrushes.Black, new XRect(40, yPoint, pagina.Width - 80, pagina.Height), XStringFormats.TopLeft);
                    yPoint += 20;

                    // Desenha as alternativas
                    foreach (var alternativa in questao.Alternativas)
                    {
                        gfx.DrawString($"{alternativa.Letra}) {alternativa.TextoAlternativa}", fonteQuestao, XBrushes.Black, new XRect(60, yPoint, pagina.Width - 80, pagina.Height), XStringFormats.TopLeft);
                        yPoint += 20;
                    }
                    yPoint += 20;
                }
                else
                {
                    // Desenha a questão
                    gfx.DrawString($"{numeroQuestao} - {questao.Enunciado}", fonteQuestao, XBrushes.Black, new XRect(40, yPoint, pagina.Width - 80, pagina.Height), XStringFormats.TopLeft);
                    yPoint += 20;

                    // Desenha as alternativas
                    foreach (var alternativa in questao.Alternativas)
                    {
                        gfx.DrawString($"{alternativa.Letra}) {alternativa.TextoAlternativa}", fonteQuestao, XBrushes.Black, new XRect(60, yPoint, pagina.Width - 80, pagina.Height), XStringFormats.TopLeft);
                        yPoint += 20;
                    }
                    yPoint += 20;
                }

                // Se estiver na última questão da primeira página, define questõesPorPagina para 6
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

            // Variável para controlar o número de questões por página
            int questoesPorPagina = 0;

            PdfPage pagina = documento.AddPage();
            pagina.Size = PageSize.A4;
            XGraphics gfx = XGraphics.FromPdfPage(pagina);

            // Define a posição inicial yPoint
            double yPoint = 40;

            // Desenha o título
            gfx.DrawString($"Gabarito - {teste.Titulo}", fonteTitulo, XBrushes.Black, new XRect(0, yPoint, pagina.Width, pagina.Height), XStringFormats.TopCenter);
            yPoint += 40;

            // Desenha a disciplina e a matéria
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
                // Verifica se é necessário adicionar uma nova página
                if ((numeroQuestao > 5 && questoesPorPagina == 0) || questoesPorPagina == 6)
                {
                    // Desenha o número da página atual
                    gfx.DrawString($"Página {numeroPagina}", fonteRodape, XBrushes.Black, new XRect(0, pagina.Height - margemInferior, pagina.Width - 40, fonteRodape.Height), XStringFormats.BottomRight);
                    numeroPagina++;

                    // Adiciona uma nova página e redefine yPoint
                    pagina = documento.AddPage();
                    pagina.Size = PageSize.A4;
                    gfx = XGraphics.FromPdfPage(pagina);
                    yPoint = 40;

                    // Redefine o contador de questões por página
                    questoesPorPagina = 0;
                }

                // Desenha a questão
                gfx.DrawString($"{numeroQuestao} - {questao.Enunciado}", fonteQuestao, XBrushes.Black, new XRect(40, yPoint, pagina.Width - 80, pagina.Height), XStringFormats.TopLeft);
                yPoint += 20;

                // Desenha as alternativas, marcando a correta em verde
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

                // Após a quinta questão na primeira página, mudar para 6 questões por página
                if (numeroQuestao == 6)
                {
                    questoesPorPagina = 0;
                }
            }

            // Desenha o número da última página
            gfx.DrawString($"Página {numeroPagina}", fonteRodape, XBrushes.Black, new XRect(0, pagina.Height - margemInferior, pagina.Width - 40, fonteRodape.Height), XStringFormats.BottomRight);

            documento.Save(caminho);

            //PdfDocument documento = new PdfDocument();
            //documento.Info.Title = "Gabarito - " + teste.Titulo;

            //XFont fonteTitulo = new XFont("Verdana", 20, XFontStyleEx.Bold);
            //XFont fonteCabecalho = new XFont("Verdana", 14, XFontStyleEx.Bold);
            //XFont fonteQuestao = new XFont("Verdana", 12, XFontStyleEx.Regular);
            //XFont fonteRodape = new XFont("Verdana", 10, XFontStyleEx.Regular);

            //int numeroPagina = 1;
            //double margemInferior = 40;
            //int questoesPorPagina = 0;

            //PdfPage pagina = documento.AddPage();
            //pagina.Size = PageSize.A4;
            //XGraphics gfx = XGraphics.FromPdfPage(pagina);

            //// Define a posição inicial yPoint
            //double yPoint = 40;

            //// Desenha o título
            //gfx.DrawString($"Gabarito - {teste.Titulo}", fonteTitulo, XBrushes.Black, new XRect(0, yPoint, pagina.Width, pagina.Height), XStringFormats.TopCenter);
            //yPoint += 40;

            //// Desenha a disciplina e a matéria
            //gfx.DrawString($"Disciplina: {teste.Disciplina.Nome}", fonteCabecalho, XBrushes.Black, new XRect(40, yPoint, pagina.Width, pagina.Height), XStringFormats.TopLeft);
            //yPoint += 30;
            //gfx.DrawString($"Matéria: {teste.Materia.Nome}", fonteCabecalho, XBrushes.Black, new XRect(40, yPoint, pagina.Width, pagina.Height), XStringFormats.TopLeft);
            //yPoint += 30;

            //int numeroQuestao = 1;

            //foreach (var questao in teste.Questoes)
            //{
            //    // Verifica se é necessário adicionar uma nova página
            //    if ((numeroQuestao > 5 && questoesPorPagina == 0) || questoesPorPagina == 6)
            //    {
            //        // Desenha o número da página atual
            //        gfx.DrawString($"Página {numeroPagina}", fonteRodape, XBrushes.Black, new XRect(0, pagina.Height - margemInferior, pagina.Width - 40, fonteRodape.Height), XStringFormats.BottomRight);
            //        numeroPagina++;

            //        // Adiciona uma nova página e redefine yPoint
            //        pagina = documento.AddPage();
            //        pagina.Size = PageSize.A4;
            //        gfx = XGraphics.FromPdfPage(pagina);
            //        yPoint = 40;

            //        // Redefine o contador de questões por página
            //        questoesPorPagina = 0;
            //    }

            //    // Desenha a questão
            //    gfx.DrawString($"{numeroQuestao} - {questao.Enunciado}", fonteQuestao, XBrushes.Black, new XRect(40, yPoint, pagina.Width - 80, pagina.Height), XStringFormats.TopLeft);
            //    yPoint += 20;

            //    // Desenha as alternativas, marcando a correta em verde
            //    foreach (var alternativa in questao.Alternativas)
            //    {
            //        if (alternativa.AlternativaCorreta)
            //        {
            //            gfx.DrawString($"{alternativa.Letra}) {alternativa.TextoAlternativa}", fonteQuestao, XBrushes.Green, new XRect(60, yPoint, pagina.Width - 80, pagina.Height), XStringFormats.TopLeft);
            //        }
            //        else
            //        {
            //            gfx.DrawString($"{alternativa.Letra}) {alternativa.TextoAlternativa}", fonteQuestao, XBrushes.Black, new XRect(60, yPoint, pagina.Width - 80, pagina.Height), XStringFormats.TopLeft);
            //        }
            //        yPoint += 20;
            //    }
            //    yPoint += 20;

            //    numeroQuestao++;
            //    questoesPorPagina++;
            //}

            //// Desenha o número da última página
            //gfx.DrawString($"Página {numeroPagina}", fonteRodape, XBrushes.Black, new XRect(0, pagina.Height - margemInferior, pagina.Width - 40, fonteRodape.Height), XStringFormats.BottomRight);

            //documento.Save(caminho);        

        }
        
    }
}
