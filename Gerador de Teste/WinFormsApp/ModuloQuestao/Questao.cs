using WinFormsApp.Compartilhado;
using WinFormsApp.ModuloMateria;

namespace WinFormsApp.ModuloQuestao
{
    public class Questao : EntidadeBase
    {
        public string Enunciado { get; set; }
    
        public string resposta = string.Empty;
        public string Resposta //retorna as alternativas
        {
            get
            {
                if(Alternativas.Count == 0)
                    return resposta;

                Alternativa alternativaCorreta = Alternativas.FirstOrDefault(a => a.AlternativaCorreta);
                return alternativaCorreta.Resposta;

                //Alternativa alternativaCorreta = Alternativas.FirstOrDefault(a => a.AlternativaCorreta);
                //return alternativaCorreta != null ? alternativaCorreta.TextoAlternativa : string.Empty;

            }
            set
            {
                resposta = value;
            }
        }       

        public List<Alternativa> Alternativas { get; set; }

        public Materia Materia { get; set; }

        public Questao()
        {
            Alternativas = new List<Alternativa>();
        }

        public Questao(string enunciado, Materia materia) : this()
        {
            Enunciado = enunciado;            
            Materia = materia;           
        }


        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Questao questao = (Questao)novoRegistro;

            Enunciado = questao.Enunciado;
            Resposta = questao.Resposta;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Enunciado.Trim()))
                erros.Add("O campo \"enunciado\" é obrigatório");

            if (Materia == null)
                erros.Add("O campo \"materia\" é obrigatório");
            int numAlternativas = Alternativas.Count;

            if (numAlternativas < 2)
                erros.Add("A questão deve ter pelo menos duas alternativas cadastradas.");
            else if (numAlternativas > 4)
                erros.Add("A questão deve ter no máximo quatro alternativas cadastradas.");

            int corretas = Alternativas.Count(a => a.AlternativaCorreta);
            if (corretas == 0)
                erros.Add("A questão deve ter pelo menos uma alternativa correta.");
            else if (corretas > 1)
                erros.Add("A questão deve ter no máximo uma alternativa correta.");

            return erros;
        }

        public override string ToString()
        {         
            return $"{Enunciado}";
        }       
    }
}
