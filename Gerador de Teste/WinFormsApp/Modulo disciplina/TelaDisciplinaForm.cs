namespace WinFormsApp.Modulo_disciplina
{
    public partial class TelaDisciplinaForm : Form
    {
        private Disciplina disciplina;
        public Disciplina Disciplina
        {
            get
            {
                return disciplina;
            }
            set
            {
                TxtID.Text = value.Id.ToString();
                TxtNome.Text = value.Nome;
            }
        }
        public TelaDisciplinaForm()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string nome = TxtNome.Text;

            disciplina = new Disciplina(nome);

            List<string> erros = Disciplina.Validar();

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);
                DialogResult = DialogResult.None;
            }
        }        
    }
}
 
