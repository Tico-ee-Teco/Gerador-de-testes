using System.Data;
using WinFormsApp.Modulo_disciplina;
using WinFormsApp.ModuloMateria;
using WinFormsApp.ModuloQuestao;

namespace WinFormsApp.ModuloTeste
{
    public partial class TelaTesteForm : Form
    {
        private Teste teste;
        private List<Questao> todasQuestoes;
        private List<Materia> todasMaterias;
        public Teste Teste
        {
            get
            {
                return teste;
            }
            set
            {
                teste = value;
                txtId.Text = value.Id.ToString();
                txtTitulo.Text = value.Titulo;

                CmbDisciplina.SelectedItem = value.Disciplina;

                CmbMateria.Enabled = value.Materia != null;
                CmbMateria.SelectedItem = value.Materia;

            }
        }

        public TelaTesteForm(List<Disciplina> disciplinas, List<Materia> materias, List<Questao> questaos)
        {
            InitializeComponent();

            CmbDisciplina.DataSource = disciplinas;
            CmbDisciplina.DisplayMember = "Nome";

            todasMaterias = materias;
            todasQuestoes = questaos;

            CmbMateria.SelectedIndexChanged += CmbMateria_SelectedIndexChanged;
            CmbDisciplina.SelectedIndexChanged += CmbDisciplina_SelectedIndexChanged;
            btnSortearQuestoes.Click += btnSortearQuestoes_Click;
            chkProvaRecuperacao.CheckedChanged += chkIncluirTodasMaterias_CheckedChanged;
            btnGravar.Enabled = false;

            AtualizarMaterias();
            AtualizarListaQuestoes();
        }

        private void CmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarMaterias();
            AtualizarListaQuestoes();
            CmbMateria.SelectedIndex = -1;
            VerificarHabilitarBotaoGravar();
        }
        private void CmbMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarListaQuestoes();
            VerificarHabilitarBotaoGravar();
        }
        private void VerificarHabilitarBotaoGravar()
        {
            if (CmbMateria.SelectedItem != null && !chkProvaRecuperacao.Checked)
            {
                btnGravar.Enabled = true; 
            }
            else
            {
                btnGravar.Enabled = false; 
            }
        }       
        private void AtualizarMaterias()
        {
            Disciplina disciplinaSelecionada = CmbDisciplina.SelectedItem as Disciplina;

            if (disciplinaSelecionada != null)
            {
                var materiasFiltradas = todasMaterias.Where(m => m.Disciplina.Id == disciplinaSelecionada.Id).ToList();

                CmbMateria.DataSource = materiasFiltradas;
                CmbMateria.DisplayMember = "Nome";
            }
        }
        private void AtualizarListaQuestoes()
        {
            List<Questao> questoesFiltradas;

            if (chkProvaRecuperacao.Checked)
            {
                questoesFiltradas = todasQuestoes.Where(q => q.Materia == null).ToList();
            }
            else
            {
                if (CmbMateria.SelectedItem == null)
                {
                    return;
                }
                var materiaSelecionada = (Materia)CmbMateria.SelectedItem;
                questoesFiltradas = todasQuestoes.Where(q => q.Materia.Id == materiaSelecionada.Id).ToList();
            }

            int quantidadeQuestoes = (int)NuUD.Value;
            var questoesExibidas = questoesFiltradas.Take(quantidadeQuestoes).ToList();

            listQuestao.DataSource = questoesExibidas;
            listQuestao.DisplayMember = "Enunciado";
        }

        private void btnSortearQuestoes_Click(object sender, EventArgs e)
        {
            if (!chkProvaRecuperacao.Checked && CmbMateria.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione uma matéria antes de sortear as questões.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<Questao> questoesFiltradas;

            if (chkProvaRecuperacao.Checked)
            {
                var disciplinaSelecionada = (Disciplina)CmbDisciplina.SelectedItem;
                questoesFiltradas = todasQuestoes.Where(q => q.Materia.Disciplina.Id == disciplinaSelecionada.Id).ToList();
            }
            else
            {
                var materiaSelecionada = (Materia)CmbMateria.SelectedItem;
                questoesFiltradas = todasQuestoes.Where(q => q.Materia.Id == materiaSelecionada.Id).ToList();
            }

            int quantidadeQuestoes = (int)NuUD.Value;

            var random = new Random();
            var questoesSorteadas = questoesFiltradas.OrderBy(q => random.Next()).Take(quantidadeQuestoes).ToList();

            listQuestao.DataSource = questoesSorteadas;
            listQuestao.DisplayMember = "Enunciado";
        }

        private void chkIncluirTodasMaterias_CheckedChanged(object sender, EventArgs e)
        {
            if (chkProvaRecuperacao.Checked)
            {
                CmbMateria.DataSource = null;
                CmbMateria.Text = "Teste de Recuperação";
            }
            else
            {
                CmbMateria.SelectedIndex = -1; 
                AtualizarMaterias(); 
            }

            CmbMateria.Enabled = !chkProvaRecuperacao.Checked;
            AtualizarListaQuestoes();

            if (chkProvaRecuperacao.Checked)
            {
                btnGravar.Enabled = true; 
            }
            else
            {
                VerificarHabilitarBotaoGravar(); 
            }

        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            string titulo = txtTitulo.Text;
            Disciplina disciplinaSelecionada = CmbDisciplina.SelectedItem as Disciplina;
            Materia materiaselecionada = CmbMateria.SelectedItem as Materia;

            List<Questao> questoesSelecionadas = listQuestao.Items.OfType<Questao>().ToList();

            Teste = new Teste(titulo, disciplinaSelecionada, materiaselecionada, questoesSelecionadas);

            List<string> erros = Teste.Validar();

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);
                DialogResult = DialogResult.None;
                return;
            }
        }
    }
}
