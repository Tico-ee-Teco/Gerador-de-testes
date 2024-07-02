
using WinFormsApp.Dominio.ModuloTeste;

namespace WinFormsApp.Infra.Sql.ModuloTeste
{
    public class RepositorioTesteEmSql : IRepositorioTeste
    {
        private string enderecoConexao;

        //private const string sqlSelecionarTodos = 
           
        public RepositorioTesteEmSql()
        {
            enderecoConexao = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=GeradorDeTesteDb;Integrated Security=True;Pooling=False";
        }
        public void Cadastrar(Teste novoTeste)
        {
            throw new NotImplementedException();
        }

        public bool Editar(int id, Teste testeSelecionado)
        {
            throw new NotImplementedException();
        }

        public bool Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public Teste SelecionarPorId(int idSelecionado)
        {
            throw new NotImplementedException();
        }

        public List<Teste> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
