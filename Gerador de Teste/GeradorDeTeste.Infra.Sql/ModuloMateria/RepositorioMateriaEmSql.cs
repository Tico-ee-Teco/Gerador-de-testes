
using Microsoft.Data.SqlClient;
using WinFormsApp.Dominio.Modulo_disciplina;
using WinFormsApp.Dominio.ModuloMateria;

namespace WinFormsApp.Infra.Sql.ModuloMateria
{
    public class RepositorioMateriaEmSql : IRepositorioMateria
    {
        private string enderecoBanco;

        public RepositorioMateriaEmSql()
        {
            enderecoBanco = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=GeradorDeTesteDb;Integrated Security=True;Pooling=False";
        }

        private const string sqlInserir =
                @"INSERT INTO [TBMATERIA]
                    (
                        [NOME],
                        [SERIE],
                        [DISCIPLINA_ID]  
                    )
                    VALUES
                    (
                        @NOME,
                        @SERIE,
                        @DISCIPLINA_ID
                    ); SELECT SCOPE_IDENTITY();";

        private const string sqlEditar = 
                @"UPDATE [TBMATERIA]
                    SET
                        [NOME] = @NOME,
                        [SERIE] = @SERIE,
                        [DISCIPLINA_ID] = @DISCIPLINA_ID
                    WHERE
                        [ID] = @ID;";

        private const string sqlexcluir = 
                @"DELETE FROM [TBMATERIA]
                    WHERE
                        [ID] = @ID;";

        private const string sqlSelecionarTodos =
                @"SELECT
                    MT.[ID],
                    MT.[NOME],
                    MT.[SERIE],
                    MT.[DISCIPLINA_ID],
                    DP.[NOME] AS [DISCIPLINA_NOME]
                FROM
                    [TBMateria] AS MT LEFT JOIN
                    [TBDisciplina] AS DP
                ON
                    DP.ID = MT.DISCIPLINA_ID;";

        private const string sqlSelecionarPorid = 
                @"SELECT
                    MT.[ID],
                    MT.[NOME],
                    MT.[SERIE],
                    MT.[DISCIPLINA_ID],
                    DP.[NOME] AS [DISCIPLINA_NOME]
                FROM
                    [TBMATERIA] AS MT LEFT JOIN
                    [TBDISCIPLINA] AS DP
                ON
                    DP.ID = MT.DISCIPLINA_ID
                WHERE
                    MT.[ID] = @ID;";

        private const string sqlMateriaComQuestao = 
                @"SELECT
                    COUNT(*)
                FROM
                    [TBQUESTAO]
                WHERE
                    [MATERIA_ID] = @ID;";

        private const string sqlMateriaComTeste = 
                @"SELECT
                    COUNT(*)
                FROM
                    [TBTESTE]
                WHERE
                    [MATERIA_ID] = @ID;";

        public void Cadastrar(Materia NovaMateria)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlInserir, conexaoComBanco);

            ConfigurarParametrosMateria(NovaMateria, comandoInsercao);

            conexaoComBanco.Open();

            object id = comandoInsercao.ExecuteScalar();

            NovaMateria.Id = Convert.ToInt32(id);

            conexaoComBanco.Close();
        }        

        public bool Editar(int id, Materia MateriaSelecionada)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoEdicao = new SqlCommand(sqlEditar, conexaoComBanco);

            MateriaSelecionada.Id = id;

            ConfigurarParametrosMateria(MateriaSelecionada, comandoEdicao);

            conexaoComBanco.Open();

            int linhasAfetadas = comandoEdicao.ExecuteNonQuery();

            conexaoComBanco.Close();

            if (linhasAfetadas < 1)
                return false;

            return true;
        }

        public bool Excluir(int id)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlexcluir, conexaoComBanco);

            comandoExclusao.Parameters.AddWithValue("ID", id);

            conexaoComBanco.Open();

            int linhasAfetadas = comandoExclusao.ExecuteNonQuery();

            conexaoComBanco.Close();

            if (linhasAfetadas < 1)
                return false;

            return true;
        }

        public bool ExisteMateriaComQuestao(int materiaId)
        {
            //Materia materia = SelecionarPorId(materiaId); //seleciona a materia pelo id

            return false;

        }

        public bool ExisteTesteComMateria(int materiaId)
        {
            return false;
        }

        public Materia SelecionarPorId(int idSelecionado)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorid, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("ID", idSelecionado);

            conexaoComBanco.Open();

            SqlDataReader leitorMateria = comandoSelecao.ExecuteReader();

            Materia materia = null;

            if (leitorMateria.Read())
                materia = ConverterParaMateria(leitorMateria);

            conexaoComBanco.Close();

            return materia;
        }       

        public List<Materia> SelecionarTodos()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos, conexaoComBanco);

            conexaoComBanco.Open();

            SqlDataReader leitorMateria = comandoSelecao.ExecuteReader();//leitura dos dados

            List<Materia> materias = new List<Materia>();//lista de materias

            while (leitorMateria.Read())
            {
                Materia materia = ConverterParaMateria(leitorMateria);// converte os dados em materia

                materias.Add(materia);//adiciona a materia na lista
            }

            conexaoComBanco.Close();

            return materias;
        }
        

        private Materia ConverterParaMateria(SqlDataReader leitorMateria)
        {
            Materia materia = new Materia()
            {
                Id = Convert.ToInt32(leitorMateria["ID"]),
                Nome = Convert.ToString(leitorMateria["NOME"]),
                Serie = Convert.ToString(leitorMateria["SERIE"]),
            };

            if (leitorMateria["DISCIPLINA_ID"] != DBNull.Value)
                materia.Disciplina = converterParaDisciplina(leitorMateria);

            return materia;
        }

        private static Disciplina converterParaDisciplina(SqlDataReader leitor)
        {

            Disciplina disciplina = new Disciplina()
            {
                Id = Convert.ToInt32(leitor["DISCIPLINA_ID"]),
                Nome = Convert.ToString(leitor["DISCIPLINA_NOME"]),
            };

            return disciplina;
        }

        private void ConfigurarParametrosMateria(Materia novaMateria, SqlCommand comandoInsercao)
        {
            comandoInsercao.Parameters.AddWithValue("ID", novaMateria.Id);
            comandoInsercao.Parameters.AddWithValue("NOME", novaMateria.Nome);
            comandoInsercao.Parameters.AddWithValue("SERIE", novaMateria.Serie);

            object valorDaDisciplina = 
                novaMateria.Disciplina == null ? DBNull.Value : novaMateria.Disciplina.Id;//se a disciplina for nula, o valor é nulo, senão é o id da disciplina

            comandoInsercao.Parameters.AddWithValue("DISCIPLINA_ID", valorDaDisciplina);
        }

      
       
    }
}
