namespace WinFormsApp.ModuloMateria
{
   public interface IRepositorioMateria 
   {
       void Cadastrar(Materia NovaMateria);
       bool Editar(int id, Materia MateriaSelecionada);
       bool Excluir(int id);
       Materia SelecionarPorId(int idSelecionado);
       List<Materia> SelecionarTodos();
       bool ExisteTesteComMateria(int materiaId);
       bool ExisteMateriaComQuestao(int materiaId);

    }
}
