using WinFormsApp.Compartilhado;

namespace WinFormsApp.ModuloTeste
{
    public class RepositorioTesteEmArquivo : RepositorioBaseEmArquivo<Teste>, IRepositorioTeste 
    {
        public RepositorioTesteEmArquivo(ContextoDados contextoDados) : base(contextoDados)
        {
            
        }
        protected override List<Teste> ObterRegistros()
        {
            return contexto.Testes;
        }
    }
}
