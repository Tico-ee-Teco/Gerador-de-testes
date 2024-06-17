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
            txtMateria.Text = teste.Materia.Nome;

            foreach(var questao in teste.Questoes)
            {
                listQuestoes.Items.Add(questao);
            }

        }
    }
}
