using WinFormsApp.Compartilhado;

namespace WinFormsApp.ModuloQuestao
{
    public class Questao : EntidadeBase
    {
        //ToDo Materias

        public string Enunciado { get; set; }

        //ToDo Alternativas

        public Questao() { }

        public Questao(string enunciado)
        {
            Enunciado = enunciado;
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

            return erros;
        }
    }
}
