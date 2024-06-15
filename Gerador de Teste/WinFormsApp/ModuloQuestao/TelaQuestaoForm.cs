
using WinFormsApp.Modulo_disciplina;
using WinFormsApp.ModuloMateria;

namespace WinFormsApp.ModuloQuestao
{
    public partial class TelaQuestaoForm : Form
    {
        private Questao questao;
        private char proximaLetra = 'A';

        public Questao Questao
        {
            get
            {
                return questao;
            }
            set
            {
                //txtId.Text = value.Id.ToString();
                //txtEnunciado.Text = value.Enunciado;
                //cmbMateria.SelectedItem = value.Materia;
                //txtResposta.Text = string.Empty;
                questao = value;

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
            cmbMateria.DisplayMember = "Nome";
        }


        private void btnGravar_Click(object sender, EventArgs e)
        {
            string enunciado = txtEnunciado.Text;
            Materia materia = (Materia)cmbMateria.SelectedItem;
            string resposta = txtResposta.Text;

            questao = new Questao(enunciado, resposta, materia);

            List<string> erros = questao.Validar();

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }
        }


        private void btnAdicionarAlternativa_Click(object sender, EventArgs e)
        {
            List<string> alternativas = AdicionarAlternativa.Select(x => x.TextoAlternativa).ToList();

            if (alternativas.Contains(txtResposta.Text))
                return;

            Alternativa alternativa = new Alternativa(proximaLetra, txtResposta.Text, false);

            listAlternativa.Items.Add(alternativa);

            proximaLetra++;

            LimparResposta();

        }



        private void LimparResposta()
        {
            txtResposta.Text = null;
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

            foreach (Alternativa alternativa in listAlternativa.CheckedItems ) 
            {
                listAlternativa.Items.Remove(alternativa);
            }               
            
        }
    }
}
