using Microsoft.Data.SqlClient;
using WinFormsApp.Dominio.ModuloMateria;
using WinFormsApp.Dominio.ModuloQuestao;

namespace WinFormsApp.Infra.Sql.ModuloQuestao
{
    public class RepositorioQuestaoEmSql : IRepositorioQuestao
    {
        private string enderecoConexao;

        public RepositorioQuestaoEmSql()
        {
            enderecoConexao = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=GeradorDeTesteDb;Integrated Security=True;Pooling=False";
        }

        #region Queries
        private const string sqlInserir =
            @"INSERT INTO [TBQUESTAO]
                    (
                        [ENUNCIADO],
                        [RESPOSTA],
                        [MATERIA_ID]
                    )
                    VALUES
                    (
                        @ENUNCIADO,
                        @RESPOSTA,
                        @MATERIA_ID
                    ); SELECT SCOPE_IDENTITY();";

        private const string sqlEditar = 
            @"UPDATE [TBQUESTAO]
                    SET
                        [ENUNCIADO] = @ENUNCIADO,
                        [RESPOSTA] = @RESPOSTA,
                        [MATERIA_ID] = @MATERIA_ID
                    WHERE
                        [ID] = @ID;";

        private const string sqlExcluir = 
            @"DELETE 
                    FROM 
                        [TBQUESTAO] 
                    WHERE 
                        [ID] = @ID;";

        private const string sqlSelecionarTodos =
            @"SELECT                    
                       QT.[ID],
                       QT.[ENUNCIADO],
                       QT.[RESPOSTA],
                       QT.[MATERIA_ID],
                       MT.[NOME] AS [MATERIA_NOME],
                       MT.[SERIE] AS [SERIE_NOME]
                    FROM
                        [TBQUESTAO] AS QT LEFT JOIN
                        [TBMATERIA] AS MT
                    ON
                       MT.ID = QT.MATERIA_ID";

        private const string sqlSelecionarPorId = 
            @"SELECT
                    QT.[ID],
                    QT.[ENUNCIADO],
                    QT.[RESPOSTA],
                    QT.[MATERIA_ID],
                    MT.[NOME] AS [MATERIA_NOME],
                    MT.[SERIE] AS [SERIE_NOME]
                FROM
                    [TBQUESTAO] AS QT LEFT JOIN
                    [TBMATERIA] AS MT
                ON
                    MT.ID = QT.MATERIA_ID
                WHERE
                    QT.ID = @ID;";

        private const string sqlSelecionarAlternativaQuestao = 
            @"SELECT
                    AT.[ID],
                    AT.[LETRA],
                    AT.[RESPOSTA],
                    AT.[ALTERNATIVACORRETA],
                    AT.[QUESTAO_ID]
                FROM
                    [TBALTERNATIVA] AS AT
                WHERE
                    AT.QUESTAO_ID = @QUESTAO_ID;";

        private const string sqlInserirAlternativa = 
            @"INSERT INTO [TBALTERNATIVA]
                    (
                        [LETRA],
                        [RESPOSTA],
                        [ALTERNATIVACORRETA],
                        [QUESTAO_ID]
                    )
                    VALUES
                    (
                        @LETRA,
                        @RESPOSTA,
                        @ALTERNATIVACORRETA,
                        @QUESTAO_ID
                    ); SELECT SCOPE_IDENTITY();";

        private const string sqlExcluirAlternativa = 
            @"DELETE 
                    FROM 
                        [TBALTERNATIVA] 
                    WHERE 
                        [QUESTAO_ID] = @QUESTAO_ID;";

        #endregion

        public void Cadastrar(Questao novaQuestao)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoConexao);

            SqlCommand comandoInsercao = new SqlCommand(sqlInserir, conexaoComBanco);

            ConfigurarParametrosQuestao(novaQuestao, comandoInsercao);

            conexaoComBanco.Open();

            object id = comandoInsercao.ExecuteScalar();

            novaQuestao.Id = Convert.ToInt32(id);

            conexaoComBanco.Close();

            AdicionarAlternativas(novaQuestao, novaQuestao.Alternativas);
        }

        public bool Editar(int id, Questao questaoSelecionada)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoConexao);

            SqlCommand comandoEdicao = new SqlCommand(sqlEditar, conexaoComBanco);

            questaoSelecionada.Id = id;

            ConfigurarParametrosQuestao(questaoSelecionada, comandoEdicao);

            conexaoComBanco.Open();

            int linhasAfetadas = comandoEdicao.ExecuteNonQuery();            

            conexaoComBanco.Close();

            if (linhasAfetadas < 1)
                return false;

            return true;
        }
       

        public bool Excluir(int id)
        {
            ExcluirAlternativas(id);

            SqlConnection conexaoComBanco = new SqlConnection(enderecoConexao);
            
            SqlCommand comandoExclusao = new SqlCommand(sqlExcluir, conexaoComBanco);

            comandoExclusao.Parameters.AddWithValue("ID", id);

            conexaoComBanco.Open();

            int linhasAfetadas = comandoExclusao.ExecuteNonQuery();

            if(linhasAfetadas < 1)
                return false;

            conexaoComBanco.Close();

            return true;
        }

        public Questao SelecionarPorId(int idSelecionado)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoConexao);

            SqlCommand comandoSelecaoPorId = new SqlCommand(sqlSelecionarPorId, conexaoComBanco);
            
            comandoSelecaoPorId.Parameters.AddWithValue("ID", idSelecionado);

            conexaoComBanco.Open();

            SqlDataReader leitorQuestao = comandoSelecaoPorId.ExecuteReader();

            Questao questao = null;

            if(leitorQuestao.Read())
                questao = ConverterParaQuestao(leitorQuestao);

            if (questao != null)
                carregarAlternativas(questao);

            conexaoComBanco.Close();

            return questao;
        }

        public List<Questao> SelecionarTodos()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoConexao);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos, conexaoComBanco);

            conexaoComBanco.Open();

            SqlDataReader leitorQuestoes = comandoSelecao.ExecuteReader();

            List<Questao> questoes = new List<Questao>();

            while (leitorQuestoes.Read())
            {
                Questao questao = ConverterParaQuestao(leitorQuestoes);

                questoes.Add(questao);
            }            

            conexaoComBanco.Close();

            return questoes;
        }

        public void Atualizar(Questao questaoAtualizada)
        {
            return;
        }
        public bool EstaEmTeste(int idQuestao)
        {
            return false;
        }

        public void AdicionarAlternativas(Questao questaoSelecionada, List<Alternativa> alternativas)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoConexao);

            conexaoComBanco.Open();

            foreach (Alternativa alternativa in alternativas)//Adiciona as alternativas
            {
                bool alternativaAdicionada = questaoSelecionada.Alternativas.Any(a => a.Id == alternativa.Id);//

                alternativa.Questao = questaoSelecionada;

                if (alternativaAdicionada)//Se a alternativa já existe, atualiza
                {
                    SqlCommand comandoInsercao = new SqlCommand(sqlInserirAlternativa, conexaoComBanco);

                    ConfigurarParametrosAlternativaQuestao(alternativa, comandoInsercao);

                    object id = comandoInsercao.ExecuteScalar();

                    alternativa.Id = Convert.ToInt32(id);
                }
            }

            Editar(questaoSelecionada.Id, questaoSelecionada);//Atualiza a questão com as alternativas

            conexaoComBanco.Close();
        }       

        private void ConfigurarParametrosQuestao(Questao novaQuestao, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", novaQuestao.Id);
            comando.Parameters.AddWithValue("ENUNCIADO", novaQuestao.Enunciado);
            comando.Parameters.AddWithValue("RESPOSTA", novaQuestao.Resposta);            

            object valorDaMateria = novaQuestao.Materia == null ? DBNull.Value : novaQuestao.Materia.Id;

            comando.Parameters.AddWithValue("MATERIA_ID", valorDaMateria);
        }

        private static Questao ConverterParaQuestao(SqlDataReader leitor)
        {
            Questao questao = new Questao()
            {
                Id = Convert.ToInt32(leitor["ID"]),
                Enunciado = Convert.ToString(leitor["ENUNCIADO"]),
                Resposta = Convert.ToString(leitor["RESPOSTA"]),
            };

            if(leitor["MATERIA_ID"] != DBNull.Value)            
                questao.Materia = ConverterParaMateria(leitor);
            
            return questao;
        }

        private static Materia ConverterParaMateria(SqlDataReader leitor)
        {
            Materia materia = new Materia()
            {
                Id = Convert.ToInt32(leitor["ID"]),
                Nome = Convert.ToString(leitor["MATERIA_NOME"]),
                Serie = Convert.ToString(leitor["SERIE_NOME"]),
            };

            //Precisa converter esse cara tb?

            //if (leitor["DISCIPLINA_ID"] != DBNull.Value) 
            //    materia.Disciplina = converterParaDisciplina(leitor);

            return materia;
        }

        private void carregarAlternativas(Questao questao)
        {

            SqlConnection conexaoComBanco = new SqlConnection(enderecoConexao);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarAlternativaQuestao, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("QUESTAO_ID", questao.Id);

            conexaoComBanco.Open();

            SqlDataReader leitorAlternativas = comandoSelecao.ExecuteReader();

            List<Alternativa> alternativas = new List<Alternativa>();

            while (leitorAlternativas.Read())
            {
                Alternativa alternativa = ConverterParaAlternativa(leitorAlternativas);

                alternativas.Add(alternativa);
            }

            questao.Alternativas = alternativas;

            conexaoComBanco.Close();
        }

        private static Alternativa ConverterParaAlternativa(SqlDataReader leitorAlternativas)
        {
            int id = Convert.ToInt32(leitorAlternativas["ID"]);
            char letra = Convert.ToChar(leitorAlternativas["LETRA"]);
            string resposta = Convert.ToString(leitorAlternativas["RESPOSTA"]);
            bool alternativaCorreta = Convert.ToBoolean(leitorAlternativas["ALTERNATIVACORRETA"]);

            Alternativa alternativa = new Alternativa
            {
                Id = id,
                Letra = letra,
                Resposta = resposta,
                AlternativaCorreta = alternativaCorreta
            };

            return alternativa;            
        }

        private void ConfigurarParametrosAlternativaQuestao(Alternativa alternativa, SqlCommand comandoInsercao)
        {
            comandoInsercao.Parameters.AddWithValue("ID", alternativa.Id);
            comandoInsercao.Parameters.AddWithValue("LETRA", alternativa.Letra);
            comandoInsercao.Parameters.AddWithValue("RESPOSTA", alternativa.Resposta);
            comandoInsercao.Parameters.AddWithValue("ALTERNATIVACORRETA", alternativa.AlternativaCorreta);
            comandoInsercao.Parameters.AddWithValue("QUESTAO_ID", alternativa.Questao.Id);
        }

        private void ExcluirAlternativas(int idQuestao)
        {
            SqlConnection conexaocomBanco = new SqlConnection(enderecoConexao);

            SqlCommand comandoExclusao = new SqlCommand(sqlExcluirAlternativa, conexaocomBanco);

            comandoExclusao.Parameters.AddWithValue("QUESTAO_ID", idQuestao);

            conexaocomBanco.Open();

            comandoExclusao.ExecuteNonQuery();

            conexaocomBanco.Close();
        }
    }
}
