namespace WinFormsApp.ModuloQuestao
{
    public partial class TelaQuestaoForm : Form
    {
        private Questao questao;

        public Questao Questao
        {
            get
            {
                return questao;
            }
            set
            {
                txtId.Text = value.Id.ToString();
                txtEnunciado.Text = value.Enunciado;
                cmbMateria.SelectedItem = value.Materia;
                txtResposta.Text = value.Resposta;
            }
        }
        public TelaQuestaoForm()
        {
            InitializeComponent();
        }
    }
}
