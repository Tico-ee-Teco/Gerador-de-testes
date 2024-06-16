using WinFormsApp.ModuloMateria;

namespace WinFormsApp.ModuloQuestao
{
    public partial class TelaQuestaoForm : Form
    {
        private Questao questao;
        public List<Alternativa> Alternativas { get; set; }
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
                txtResposta.Text = string.Empty;

                listAlternativa.Items.Clear();

                listAlternativa.SelectedItem = value.Alternativas;

                foreach (var alternativa in value.Alternativas)
                {
                    listAlternativa.Items.Add(alternativa, alternativa.AlternativaCorreta);
                }
            }
        }

        public List<Alternativa> AdicionarAlternativa
        {
            get
            {
                return listAlternativa.Items.Cast<Alternativa>().ToList();
            }
        }

        public TelaQuestaoForm(List<Materia> materias)
        {
            InitializeComponent();

            cmbMateria.DataSource = materias;
            cmbMateria.DisplayMember ="Nome" + "Serie";

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {           
            string enunciado = txtEnunciado.Text;
            Materia materia = (Materia)cmbMateria.SelectedItem;

            questao = new Questao(enunciado, materia);
          
            foreach (var item in listAlternativa.Items)
            {
                Alternativa alternativas = item as Alternativa;
                if (alternativas != null)
                {
                    alternativas.AlternativaCorreta = listAlternativa.CheckedItems.Contains(alternativas);
                    questao.Alternativas.Add(alternativas);
                }
            }
            ControladorQuestao controlador = new ControladorQuestao(null, null);
            List<string> erros = questao.Validar();

            if (erros.Count > 0)
            {
                MessageBox.Show(
                    string.Join("\n", erros),
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                DialogResult = DialogResult.None; 
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }
       
        private void btnAdicionarAlternativa_Click(object sender, EventArgs e)
        {

            char proximaLetra = (char)('A' + listAlternativa.Items.Count);

            Alternativa alternativa = new(proximaLetra, txtResposta.Text, false);

            listAlternativa.Items.Add(alternativa, false);

            txtResposta.Clear();
            
        }

        private void btnRemoverAlternativa_Click(object sender, EventArgs e)
        {
            List<Alternativa> itensRemover = new List<Alternativa>();

            
            foreach (var item in listAlternativa.CheckedItems)
            {
                Alternativa alternativa = item as Alternativa;

                if (alternativa != null)
                {
                    itensRemover.Add(alternativa);
                }
            }

            
            foreach (Alternativa alternativa in itensRemover)
            {
                listAlternativa.Items.Remove(alternativa);
            }
        }
    }
}
