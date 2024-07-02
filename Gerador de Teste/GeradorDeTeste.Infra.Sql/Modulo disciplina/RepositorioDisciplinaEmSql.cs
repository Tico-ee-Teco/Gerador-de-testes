using Microsoft.Data.SqlClient;
using WinFormsApp.Dominio.Modulo_disciplina;

namespace WinFormsApp.Infra.Sql.Modulo_disciplina
{
    public class RepositorioDisciplinaEmSql : IRepositorioDisciplina
    {

        private string enderecoBanco;

        public RepositorioDisciplinaEmSql()
        {
            enderecoBanco = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=GeradorDeTesteDb;Integrated Security=True;Pooling=False";
        }
        public void Cadastrar(Disciplina NovaDisciplina)
        {
            string sqlInserir =
                @"INSERT INTO [TBDISCIPLINA]
                    (
                        [NOME]
                    )
                    VALUES
                    (
                        @NOME
                    ); SELECT SCOPE_IDENTITY();"; //query de inserção

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlInserir, conexaoComBanco);

            ConfigurarParametros(NovaDisciplina, comandoInsercao); //configura os parametros
                
            conexaoComBanco.Open(); //  abre a conexao com o banco

            object id = comandoInsercao.ExecuteScalar(); //executa a inserção

            NovaDisciplina.Id = Convert.ToInt32(id); //converte o id para inteiro

            conexaoComBanco.Close();//fecha a conexao com o banco
        }

        public bool Editar(int id, Disciplina DisciplinaSelecionada)
        {
            string sqlEditar =
                 @"UPDATE [TBDISCIPLINA]
                            SET
                                    [NOME] = @NOME
                            WHERE
                                    [ID] = @ID"; //query de edição

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoEdicao = new SqlCommand(sqlEditar, conexaoComBanco);

            DisciplinaSelecionada.Id = id; //id da disciplina selecionada

            ConfigurarParametros(DisciplinaSelecionada, comandoEdicao); //configura os parametros

            conexaoComBanco.Open(); //abre a conexao com o banco

            int linhasAfetadas = comandoEdicao.ExecuteNonQuery(); //executa a edição

            conexaoComBanco.Close(); //fecha a conexao com o banco

            if(linhasAfetadas < 1) //se não houver linhas afetadas
                return false;
            
            return true;
        }

        public bool Excluir(int id)
        {
            string sqlExcluir =
                @"DELETE FROM [TBDISCIPLINA]
                            WHERE
                                    [ID] = @ID"; //query de exclusão

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlExcluir, conexaoComBanco);

            comandoExclusao.Parameters.AddWithValue("ID", id);//parametro id

            conexaoComBanco.Open();

            int linhasAfetadas = comandoExclusao.ExecuteNonQuery();//executa a exclusão

            conexaoComBanco.Close(); //fecha a conexao com o banco

            if(linhasAfetadas < 1)//se não houver linhas afetadas
                return false;

            return true;
        }

        public bool ExisteDisciplinaComMateria(int DisciplinaId)
        {
            return false;
        }

        public bool ExisteTesteComDisciplina(int DiscipinaId)
        {
            return false;
        }

        public Disciplina SelecionarPorId(int idSelecionado)
        {
            string sqlSelecionarPorId =
                @"SELECT
                        [ID],
                        [NOME]
                    FROM
                        [TBDISCIPLINA]
                WHERE
                    [ID] = @ID"; //query de seleção

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorId, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("ID", idSelecionado);//parametro id

            conexaoComBanco.Open();

            SqlDataReader leitorDisciplina = comandoSelecao.ExecuteReader();//leitura dos dados

            Disciplina disciplina = null;//disciplina nula

            if(leitorDisciplina.Read()) //se tiver dados para serem lidos
                disciplina = ConverterParaDisciplina(leitorDisciplina); //converte os dados em disciplina

            conexaoComBanco.Close();

            return disciplina; //retorna a disciplina
        }

        public List<Disciplina> SelecionarTodos()
        {
            string sqlSelecionarTodos =
                @"SELECT
                        [ID],
                        [NOME]
                FROM
                        [TBDISCIPLINA]"; //query de seleção

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos, conexaoComBanco); 

            conexaoComBanco.Open(); //abre a conexao com o banco

            SqlDataReader leitorDisciplina = comandoSelecao.ExecuteReader(); //leiturna dos dados

            List<Disciplina> disciplinas = new List<Disciplina>();//lista de disciplinas

            while (leitorDisciplina.Read()) //enquanto tiver dados para serem lidos
            {
                Disciplina disciplina = ConverterParaDisciplina(leitorDisciplina); //converte os dados em disciplina

                disciplinas.Add(disciplina); //adiciona a disciplina na lista
            }

            conexaoComBanco.Close();//fecha a conexao com o banco

            return disciplinas; //retorna a lista de disciplinas
        } //seleciona todas as disciplinas

        private Disciplina ConverterParaDisciplina(SqlDataReader leitorDisciplina) //converte os dados em disciplina
        {
            Disciplina disciplina = new Disciplina()
            {
                Id = Convert.ToInt32(leitorDisciplina["ID"]),
                Nome = Convert.ToString(leitorDisciplina["NOME"]),
            };

            return disciplina;
        }

        private void ConfigurarParametros(Disciplina disciplina, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", disciplina.Id);
            comando.Parameters.AddWithValue("NOME", disciplina.Nome);
        } //configura os parametros
    }
}
