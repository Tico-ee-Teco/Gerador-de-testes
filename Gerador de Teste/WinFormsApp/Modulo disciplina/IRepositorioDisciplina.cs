namespace WinFormsApp.Modulo_disciplina
{   
    public interface IRepositorioDisciplina
    {
        void Cadastrar(Disciplina NovaDisciplina);
        bool Editar(int id, Disciplina DisciplinaSelecionada);
        bool Excluir(int id);
        Disciplina SelecionarPorId(int idSelecionado);
        List<Disciplina> SelecionarTodos();
        bool ExisteTesteComDisciplina(int DiscipinaId);
        bool ExisteDisciplinaComMateria(int DisciplinaId);
    }    
}
