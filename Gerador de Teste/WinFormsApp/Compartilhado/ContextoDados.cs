using System.Text.Json;
using System.Text.Json.Serialization;
using WinFormsApp.Modulo_disciplina;
using WinFormsApp.ModuloMateria;
using WinFormsApp.ModuloQuestao;
using WinFormsApp.ModuloTeste;

namespace WinFormsApp.Compartilhado
{
    public class ContextoDados
    {
        public List<Disciplina> Disciplinas{ get; set; }
        public List<Materia> Materias { get; set; }
        public List<Questao> Questoes { get; set; }
        public List<Alternativa> Alternativas { get; set; }
        public List<Teste> Testes { get; set; }
        
 
        private string caminho = $"C:\\temp\\GeradorDeTestes\\dados.json";

        public ContextoDados()
        {
            Disciplinas = new List<Disciplina>();
            Materias = new List<Materia>();  
            Questoes = new List<Questao>();
            Alternativas = new List<Alternativa>();
            Testes = new List<Teste>();
        }

        public ContextoDados(bool carregarDados) : this()
        {
            if (carregarDados)
                CarregarDados();
        }

        public void Gravar()
        {
            FileInfo arquivos = new FileInfo(caminho);

            arquivos.Directory.Create();

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };

            byte[] registrosEmBytes = JsonSerializer.SerializeToUtf8Bytes(this, options);

            File.WriteAllBytes(caminho, registrosEmBytes);
        }

        protected void CarregarDados()
        {
            FileInfo arquivo = new FileInfo(caminho);

            if (!arquivo.Exists)
                return;

            byte[] registrosEmBytes = File.ReadAllBytes(caminho);

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            ContextoDados ctx = JsonSerializer.Deserialize<ContextoDados>(registrosEmBytes, options);

            if (ctx == null) return;

            Disciplinas = ctx.Disciplinas;
            Materias = ctx.Materias;
            Questoes = ctx.Questoes;
            Alternativas = ctx.Alternativas;
            Testes = ctx.Testes;
        }

    }
}
