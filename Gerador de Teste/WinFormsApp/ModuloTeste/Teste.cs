using WinFormsApp.Compartilhado;
using WinFormsApp.Modulo_disciplina;
using WinFormsApp.ModuloMateria;
using WinFormsApp.ModuloQuestao;

namespace WinFormsApp.ModuloTeste
{
    public class Teste : EntidadeBase
    {
        public string Titulo { get; set; }
        public Disciplina Disciplina { get; set; }
        public Materia Materia { get; set; }
        public int QtdeQuestoes { get; set; }
        public bool ProvaRecuperacao { get; set; }
        public List<Questao> Questoes { get; set; }
        public Teste() { }      

        public Teste(string titulo, Disciplina disciplina, Materia materia, List<Questao> questoes)
        {
            Titulo = titulo;
            Disciplina = disciplina;
            Materia = materia;
            Questoes = questoes ?? new List<Questao>();
            QtdeQuestoes = Questoes.Count;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Titulo.Trim()))
                erros.Add("O campo \"titulo\" é obrigatório");
            if (Disciplina == null)
                erros.Add("O campo \"disciplina\" é obrigatório");
            if (ProvaRecuperacao && Materia == null)
                erros.Add("O campo \"materia\" é obrigatório");
            if (QtdeQuestoes <= 0)
                erros.Add("O campo \"Quantidade de questoes\" deve ser maior do que zero");

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Teste teste = (Teste)novoRegistro;

            Titulo = teste.Titulo;
            Disciplina = teste.Disciplina;
            Materia = teste.Materia;
            Questoes = teste.Questoes;
            QtdeQuestoes = teste.QtdeQuestoes;
            ProvaRecuperacao = teste.ProvaRecuperacao;
        }              

        public override string ToString()
        {
            return $"{Titulo} {Disciplina.Nome} {Materia.Nome} {Materia.Serie} {QtdeQuestoes}";
        }
    }
}
