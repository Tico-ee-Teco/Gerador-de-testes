namespace WinFormsApp.Dominio.ModuloTeste
{
    public interface IRepositorioTeste
    {
        void Cadastrar(Teste novoTeste);
        bool Editar(int id, Teste testeSelecionado);
        bool Excluir(int id);
        Teste SelecionarPorId(int idSelecionado);
        List<Teste> SelecionarTodos();
    }
}
