using WinFormsApp.Compartilhado;
using WinFormsApp.Dominio.Modulo_disciplina;
using WinFormsApp.Dominio.ModuloMateria;
using WinFormsApp.Dominio.ModuloTeste;

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
        public bool ExisteTesteComDisciplina(int DisciplinaId)
        {
            List<Teste> testes = contexto.Testes;

            foreach (Teste teste in testes)
            {
                if (teste.Disciplina != null && teste.Disciplina.Id == DisciplinaId)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ExisteDisciplinaComMateria(int DisciplinaId)
        {
            List<Materia> materias = contexto.Materias;

            foreach (Materia materia in materias)
            {
                if (materia.Disciplina != null && materia.Disciplina.Id == DisciplinaId)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
        
   

