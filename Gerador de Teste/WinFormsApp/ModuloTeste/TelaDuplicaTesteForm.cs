using WinFormsApp.Modulo_disciplina;
using WinFormsApp.ModuloMateria;
using WinFormsApp.ModuloQuestao;

namespace WinFormsApp.ModuloTeste
{
    public partial class TelaDuplicaTesteForm : Form
    {
        private List<Questao> todasQuestoes;
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
       
        public TelaDuplicaTesteForm(Teste teste, List<Disciplina> disciplinas, List<Materia> materias,List<Questao> questaos)
        {
            InitializeComponent();
            this.teste = teste;

            todasQuestoes = questaos;

            CarregarDisciplina(disciplinas);
            CarregarMateria(materias);
            DuplicarTeste();
            //InitializeComponent();

            //CmbDisciplina.DataSource = disciplinas;
            //CmbDisciplina.DisplayMember = "Nome";

            //todasMaterias = materias;
            //todasQuestoes = questaos;

            //CmbMateria.SelectedIndexChanged += CmbMateria_SelectedIndexChanged;
            //CmbDisciplina.SelectedIndexChanged += CmbDisciplina_SelectedIndexChanged;
            //btnSortearQuestoes.Click += btnSortearQuestoes_Click;
            //chkProvaRecuperacao.CheckedChanged += chkIncluirTodasMaterias_CheckedChanged;
            //btnGravar.Enabled = false;

            //AtualizarMaterias();
            //AtualizarListaQuestoes();
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
            bool isRecuperacao = teste.Materia == null;

            chkDuplicadoRecuperacao.Checked = isRecuperacao;

            cmbDuplicidadeMateria.Enabled = !isRecuperacao;

            foreach (var item in cmbDuplicacaoDisciplina.Items)
            {
                if (item is Disciplina disciplina && disciplina.Id == teste.Disciplina.Id)
                {
                    cmbDuplicacaoDisciplina.SelectedItem = item;
                    break;
                }
            }
            foreach (var item in cmbDuplicidadeMateria.Items)
            {
                if (item is Materia materia)
                {
                    if ((teste.Materia == null && materia == null) ||
                        (teste.Materia != null && materia != null && materia.Id == teste.Materia.Id))
                    {
                        cmbDuplicidadeMateria.SelectedItem = item;
                        break;
                    }
                }
            }          
            nudQtdeDuplicidade.Value = teste.QtdeQuestoes;
        }
    }
}
