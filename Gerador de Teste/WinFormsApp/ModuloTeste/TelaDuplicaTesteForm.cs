using WinFormsApp.Modulo_disciplina;
using WinFormsApp.ModuloMateria;

namespace WinFormsApp.ModuloTeste
{
    public partial class TelaDuplicaTesteForm : Form
    {
        public Teste teste { get; set; }
        public Teste Teste
        {
            get
            {
                return teste;
            }
            set
            {
                txtDuplicacaoTitulo.Text = value.Titulo;
                cmbDuplicacaoDisciplina.SelectedItem = value.Disciplina;
                cmbDuplicidadeMateria.SelectedItem = value.Materia;
                nudQtdeDuplicidade.Value = value.QtdeQuestoes;
            }
        }
       
        public TelaDuplicaTesteForm(Teste teste, List<Disciplina> disciplinas, List<Materia> materias)
        {
            InitializeComponent();
            this.teste = teste;

            CarregarDisciplina(disciplinas);
            CarregarMateria(materias);
            DuplicarTeste();
        }

        public void CarregarDisciplina(List<Disciplina> disciplinas)
        {
            cmbDuplicacaoDisciplina.Items.Clear();

            foreach (Disciplina d in disciplinas)
                cmbDuplicacaoDisciplina.Items.Add(d);

            cmbDuplicacaoDisciplina.DisplayMember = "Nome";
        }

        public void CarregarMateria(List<Materia> materias)
        {
            cmbDuplicidadeMateria.Items.Clear();

            foreach (Materia m in materias)
                cmbDuplicidadeMateria.Items.Add(m);

            cmbDuplicidadeMateria.DisplayMember = "Nome";
        }

       
        public void DuplicarTeste()
        {

            foreach(var item in cmbDuplicacaoDisciplina.Items)
            {
                if (item is Disciplina disciplina && disciplina.Id == teste.Disciplina.Id)
                {
                    cmbDuplicacaoDisciplina.SelectedItem = item;
                    break;
                }
            }

            foreach (var item in cmbDuplicidadeMateria.Items)
            {
                if (item is Materia materia && materia.Id == teste.Materia.Id)
                {
                    cmbDuplicidadeMateria.SelectedItem = item;
                    break;
                }
            }
            txtDuplicacaoTitulo.Text = teste.Titulo;
            nudQtdeDuplicidade.Value = teste.QtdeQuestoes;
        }
    }
}
