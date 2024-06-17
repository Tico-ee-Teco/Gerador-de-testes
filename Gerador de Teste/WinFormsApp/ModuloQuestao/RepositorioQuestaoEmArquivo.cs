using WinFormsApp.Compartilhado;
using WinFormsApp.ModuloTeste;

namespace WinFormsApp.ModuloQuestao
{
    public class RepositorioQuestaoEmArquivo : RepositorioBaseEmArquivo<Questao>, IRepositorioQuestao
    {
        public RepositorioQuestaoEmArquivo(ContextoDados contexto) : base(contexto)
        {
            
        }
        protected override List<Questao> ObterRegistros()
        {
            return contexto.Questoes;
        }
        public bool EstaEmTeste(int idQuestao)
        {
            List<Teste> testes = contexto.Testes;

            foreach (Teste teste in testes)
            {
                foreach (Questao questao in teste.Questoes)
                {
                    if (questao.Id == idQuestao)
                    {
                        return true;
                    }
                }
            }
            return false; 
        }

    }
}
