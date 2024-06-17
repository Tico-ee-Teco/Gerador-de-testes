namespace WinFormsApp.ModuloTeste
{
    public partial class TelaDuplicaTesteForm : Form
    {
        public Teste teste { get; set; }
        public TelaDuplicaTesteForm(Teste teste)
        {
            InitializeComponent();
            this.teste = teste;

            DuplicarTeste();
        }

        public void DuplicarTeste()
        {
            cmbDuplicacaoDisciplina.SelectedItem = teste.Disciplina;
            cmbDuplicidadeMateria.SelectedItem = teste.Materia;
            nudQtdeDuplicidade.Value = teste.QtdeQuestoes;
        }
    }
}
