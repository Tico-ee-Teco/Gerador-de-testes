using WinFormsApp.ModuloMateria;

namespace WinFormsApp.ModuloQuestao
{
    public partial class TelaQuestaoForm : Form
    {
        private Questao questao;
        public List<Alternativa> Alternativas { get; set; }

        private List<Questao> questoes;
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
            cmbMateria.DisplayMember = "Nome" + "Serie";

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

            if (ExisteQuestao(enunciado))
            {
                MessageBox.Show(
                    "Já existe uma questão com esse enunciado.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                DialogResult = DialogResult.None;
                return;
            }

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
                return;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnAdicionarAlternativa_Click(object sender, EventArgs e)
        {
            char proximaLetra = (char)('A' + listAlternativa.Items.Count);

            Alternativa alternativa = new(proximaLetra, txtResposta.Text, false);

            listAlternativa.Items.Add(alternativa, false);

            RecalcularLetrasAlternativas();

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
            RecalcularLetrasAlternativas();
        }
        private void RecalcularLetrasAlternativas()
        {
            for (int i = 0; i < listAlternativa.Items.Count; i++)
            {
                Alternativa alternativa = listAlternativa.Items[i] as Alternativa;
                if (alternativa != null)
                {
                    alternativa.Letra = (char)('A' + i);
                    listAlternativa.Items[i] = alternativa;
                }
            }
        }

        public bool ExisteQuestao(string enunciado)
        {
            return questoes.Any(q => q.Enunciado == enunciado);
        }

        private void cmbMateria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
