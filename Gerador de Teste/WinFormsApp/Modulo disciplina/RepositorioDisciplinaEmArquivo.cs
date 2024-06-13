using WinFormsApp.Compartilhado;

namespace WinFormsApp.Modulo_disciplina
{
    public class RepositorioDisciplinaEmArquivo : RepositorioBaseEmArquivo<Disciplina>,IRepositorioDisciplina
    {
        public RepositorioDisciplinaEmArquivo(ContextoDados contexto) : base(contexto)
        {
        }
        protected override List<Disciplina> ObterRegistros()
        {
            return contexto.Disciplinas;
        }


    }
}
        
   

