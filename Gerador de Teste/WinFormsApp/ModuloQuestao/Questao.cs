using WinFormsApp.Compartilhado;
using WinFormsApp.ModuloMateria;

namespace WinFormsApp.ModuloQuestao
{
    public class Questao : EntidadeBase
    {
        public string Enunciado { get; set; }
        public string Resposta
        {
            get
            {
                Alternativa alternativaCorreta = Alternativas.FirstOrDefault(a => a.AlternativaCorreta);
                return alternativaCorreta != null ? alternativaCorreta.TextoAlternativa : string.Empty;
            }
        }       

        public List<Alternativa> Alternativas { get; set; }

        public Materia Materia { get; set; }

        public Questao() { }

        public Questao(string enunciado, Materia materia)
        {
            Enunciado = enunciado;            
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

            if (Materia == null)
                erros.Add("O campo \"materia\" é obrigatório");
             
            int corretas = Alternativas.Count(a => a.AlternativaCorreta);
            if (corretas != 1)
                erros.Add("A questão deve ter no maximo uma alternativa Correta e no minimo uma Correta.");

            return erros;
        }

        public override string ToString()
        {
            //return $"Enunciado: {Enunciado} - Materia: {Materia.Nome} - Resposta: {Resposta}";
            return $"Enunciado: {Enunciado}";
        }

       
    }
}
