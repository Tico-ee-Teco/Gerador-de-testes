using WinFormsApp.Compartilhado;

namespace WinFormsApp.ModuloQuestao
{
    public class Alternativa : EntidadeBase
    {        
        public char Letra { get; set; }
        public string Resposta{ get; set; }
        public bool AlternativaCorreta {  get; set; }
        public Questao Questao { get; set; }

        public Alternativa() { }

        public Alternativa(char letra, string reposta, bool alternativaCorreta)
        {
            Letra = letra;
            Resposta = reposta;
            AlternativaCorreta = alternativaCorreta;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Alternativa alternativa = (Alternativa)novoRegistro;

            Letra = alternativa.Letra;
            Resposta = alternativa.Resposta;
            AlternativaCorreta = alternativa.AlternativaCorreta;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Resposta.Trim()))
                erros.Add("O campo \"enunciado\" é obrigatório");

            return erros;
        }

        public override string ToString()
        {
            return $"({Letra}) -> {Resposta}";
        }
    }
}
