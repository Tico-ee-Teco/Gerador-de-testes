using WinFormsApp.Dominio.ModuloTeste;

namespace WinFormsApp.ModuloTeste
{
    public partial class TelaVisualizaTesteForm : Form
    {
        public Teste teste { get; set; }
        public TelaVisualizaTesteForm(Teste teste)
        {
            InitializeComponent();
            this.teste = teste;

            ExibirDetalhesTeste();
        }

        private void ExibirDetalhesTeste()
        {
            txtTitulo.Text = teste.Titulo;           
            txtDisciplina.Text = teste.Disciplina.Nome;          
            if (teste.Materia != null)
            {
                txtMateria.Text = teste.Materia.Nome;
            }
            else
            {
                txtMateria.Text = "Teste de Recuperação";
            }

            foreach (var questao in teste.Questoes)
            {
                listQuestoes.Items.Add(questao);
            }
        }
    }
}
