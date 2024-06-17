using WinFormsApp.Compartilhado;

namespace WinFormsApp.ModuloQuestao
{
    public class Alternativa : EntidadeBase
    {        
        public char Letra { get; set; }
        public string TextoAlternativa { get; set; }
        public bool AlternativaCorreta {  get; set; }

        public Alternativa() { }

        public Alternativa(char letra, string textoAlternativa, bool alternativaCorreta)
        {
            Letra = letra;
            TextoAlternativa = textoAlternativa;
            AlternativaCorreta = alternativaCorreta;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Alternativa alternativa = (Alternativa)novoRegistro;

            Letra = alternativa.Letra;
            TextoAlternativa = alternativa.TextoAlternativa;
            AlternativaCorreta = alternativa.AlternativaCorreta;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(TextoAlternativa.Trim()))
                erros.Add("O campo \"enunciado\" é obrigatório");

            return erros;
        }

        public override string ToString()
        {
            return $"({Letra}) -> {TextoAlternativa}";
        }
    }
}
