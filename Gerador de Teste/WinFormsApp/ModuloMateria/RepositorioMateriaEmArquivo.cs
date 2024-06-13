
using WinFormsApp.Compartilhado;

namespace WinFormsApp.ModuloMateria
{
    public class RepositorioMateriaEmArquivo : RepositorioBaseEmArquivo<Materia>, IRepositorioMateria
    {
        public RepositorioMateriaEmArquivo( ContextoDados contexto) : base(contexto)
        {

        }
        protected override List<Materia> ObterRegistros()
        {
            return contexto.Materias;
        }
    }
}
