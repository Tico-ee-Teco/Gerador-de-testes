using WinFormsApp.Compartilhado;
using WinFormsApp.Dominio.ModuloMateria;
using WinFormsApp.Dominio.ModuloQuestao;
using WinFormsApp.Dominio.ModuloTeste;
using WinFormsApp.ModuloQuestao;
using WinFormsApp.ModuloTeste;

namespace WinFormsApp.ModuloMateria
{
    public class RepositorioMateriaEmArquivo : RepositorioBaseEmArquivo<Materia>, IRepositorioMateria
    {
        public RepositorioMateriaEmArquivo(ContextoDados contexto) : base(contexto)
        {

        }
        protected override List<Materia> ObterRegistros()
        {
            return contexto.Materias;
        }
        public bool ExisteTesteComMateria(int idMateria)
        {
            List<Teste> testes = contexto.Testes;

            foreach (Teste teste in testes)
            {
                if (teste.Materia != null && teste.Materia.Id == idMateria)
                {
                    return true;
                }
            }
            return false;
        }
        public bool ExisteMateriaComQuestao(int idMateria)
        {
            List<Questao> questoes = contexto.Questoes;

            foreach (Questao questao in questoes)
            {
                if (questao.Materia != null && questao.Materia.Id == idMateria)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
