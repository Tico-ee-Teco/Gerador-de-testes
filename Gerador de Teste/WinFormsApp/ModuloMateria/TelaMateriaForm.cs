using WinFormsApp.Dominio.Modulo_disciplina;
using WinFormsApp.Dominio.ModuloMateria;

namespace WinFormsApp.ModuloMateria
{
    public partial class TelaMateriaForm : Form
    {
        private Materia materia;
        public Materia Materia
        {
            get
            {
                return materia;
            }
            set
            {
                materia = value;
                TxtID.Text = value.Id.ToString();
                TxtNome.Text = value.Nome;
                CmbDisciplina.SelectedItem = value.Disciplina;
                if (value.Serie == "1ª")
                    RB1Serie.Checked = true;
                else if (value.Serie == "2ª")
                    RB2Serie.Checked = true;
            }
        }
        public TelaMateriaForm(List<Disciplina> disciplinas)
        {
            InitializeComponent();

            CmbDisciplina.DataSource = disciplinas;
            CmbDisciplina.DisplayMember = "Nome";
        }         

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string nome = TxtNome.Text;
            Disciplina disciplinaSelecionada = (Disciplina)CmbDisciplina.SelectedItem;
            string serie = RB1Serie.Checked ? "1ª Serie" : RB2Serie.Checked ? "2ª Serie" : string.Empty;

            materia = new Materia(nome, disciplinaSelecionada, serie);

            List<string> erros = materia.Validar();

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);
                DialogResult = DialogResult.None;
                return;
            }

        }
    }
}
