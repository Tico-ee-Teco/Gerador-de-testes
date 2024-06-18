namespace WinFormsApp.Compartilhado
{
    public interface IControladorGeraPdf
    {
        string ToolTipGeradorPDFTeste { get; }
        string ToolTipGeradorPDFGabarito { get; }
        void GerarTestePDF();
        void GerarGabaritoPDF();
    }
}
