using WinFormsApp.Compartilhado;
using WinFormsApp.ModuloMateria;

namespace WinFormsApp.ModuloQuestao
{
    public class Questao : EntidadeBase
    {
        public string Enunciado { get; set; }

        public string Resposta { get; set; }

        public List<Alternativa> Alternativas { get; set; }

        public Materia Materia { get; set; }

        public Questao() { }

        public Questao(string enunciado, string resposta, Materia materia)
        {
            Enunciado = enunciado;
            Resposta = resposta;
            Materia = materia;

            Alternativas = new List<Alternativa>();
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Questao questao = (Questao)novoRegistro;

            Enunciado = questao.Enunciado;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Enunciado.Trim()))
                erros.Add("O campo \"enunciado\" é obrigatório");

            //if (Resposta > 5 || Resposta < 2)
            //    erros.Add("O campo \"resposta\" é obrigatorio");

            return erros;
        }
    }
}
