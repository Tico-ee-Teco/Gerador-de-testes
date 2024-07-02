using WinFormsApp.Dominio.Modulo_disciplina;
using WinFormsApp.Dominio.ModuloMateria;
using WinFormsApp.Dominio.ModuloQuestao;
using WinFormsApp.Dominio.ModuloTeste;

namespace WinFormsApp.ModuloTeste
{
    public partial class TelaDuplicaTesteForm : Form
    {
        public Teste teste;
        private List<Questao> todasQuestoes;
        private List<Materia> todasMaterias;
        private List<Disciplina> disciplinas;
        private List<Materia> materias;
        private List<Questao> questaos;

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
                txtDuplicacaoTitulo.Text = value.Titulo;

                cmbDuplicacaoDisciplina.SelectedItem = value.Disciplina;

                cmbDuplicidadeMateria.Enabled = value.Materia != null;
                cmbDuplicidadeMateria.SelectedItem = value.Materia;
                chkDuplicadoRecuperacao.Checked = value.ProvaRecuperacao;
            }
        }

        public TelaDuplicaTesteForm(Teste teste, List<Disciplina> disciplinas, List<Materia> materias, List<Questao> questaos)
        {
            InitializeComponent();
            this.teste = teste;

            cmbDuplicacaoDisciplina.DataSource = disciplinas;
            cmbDuplicacaoDisciplina.DisplayMember = "Nome";

            todasMaterias = materias;
            todasQuestoes = questaos;

            cmbDuplicidadeMateria.SelectedIndexChanged += CmbMateria_SelectedIndexChanged;
            cmbDuplicacaoDisciplina.SelectedIndexChanged += CmbDisciplina_SelectedIndexChanged;
            btnDuplicidadeSortearQuestoes.Click += btnSortearQuestoes_Click;
            chkDuplicadoRecuperacao.CheckedChanged += chkIncluirTodasMaterias_CheckedChanged;
            btnGravar.Enabled = false;

            AtualizarMaterias();
            AtualizarListaQuestoes();
            DuplicarTeste();
        }

        public TelaDuplicaTesteForm(List<Disciplina> disciplinas, List<Materia> materias, List<Questao> questaos)
        {
            this.disciplinas = disciplinas;
            this.materias = materias;
            this.questaos = questaos;
        }

        private void CmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarMaterias();
            AtualizarListaQuestoes();
            cmbDuplicidadeMateria.SelectedIndex = -1;
            VerificarHabilitarBotaoGravar();
        }

        private void CmbMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarListaQuestoes();
            VerificarHabilitarBotaoGravar();
        }

        private void VerificarHabilitarBotaoGravar()
        {
            if (cmbDuplicidadeMateria.SelectedItem != null && !chkDuplicadoRecuperacao.Checked)
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
            Disciplina disciplinaSelecionada = cmbDuplicacaoDisciplina.SelectedItem as Disciplina;

            if (disciplinaSelecionada != null)
            {
                var materiasFiltradas = todasMaterias.Where(m => m.Disciplina.Id == disciplinaSelecionada.Id).ToList();

                cmbDuplicidadeMateria.DataSource = materiasFiltradas;
                cmbDuplicidadeMateria.DisplayMember = "Nome";
            }
        }

        private void AtualizarListaQuestoes()
        {
            List<Questao> questoesFiltradas;

            if (chkDuplicadoRecuperacao.Checked)
            {
                questoesFiltradas = todasQuestoes.Where(q => q.Materia == null).ToList();
            }
            else
            {
                if (cmbDuplicidadeMateria.SelectedItem == null)
                {
                    return;
                }
                var materiaSelecionada = (Materia)cmbDuplicidadeMateria.SelectedItem;
                questoesFiltradas = todasQuestoes.Where(q => q.Materia.Id == materiaSelecionada.Id).ToList();
            }

            int quantidadeQuestoes = (int)nudQtdeDuplicidade.Value;
            var questoesExibidas = questoesFiltradas.Take(quantidadeQuestoes).ToList();

            listDuplicidadeQuestao.DataSource = questoesExibidas;
            listDuplicidadeQuestao.DisplayMember = "Enunciado";
        }

        private void btnSortearQuestoes_Click(object sender, EventArgs e)
        {
            if (!chkDuplicadoRecuperacao.Checked && cmbDuplicidadeMateria.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione uma matéria antes de sortear as questões.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<Questao> questoesFiltradas;

            if (chkDuplicadoRecuperacao.Checked)
            {
                var disciplinaSelecionada = (Disciplina)cmbDuplicacaoDisciplina.SelectedItem;
                questoesFiltradas = todasQuestoes.Where(q => q.Materia.Disciplina.Id == disciplinaSelecionada.Id).ToList();
            }
            else
            {
                var materiaSelecionada = (Materia)cmbDuplicidadeMateria.SelectedItem;
                questoesFiltradas = todasQuestoes.Where(q => q.Materia.Id == materiaSelecionada.Id).ToList();
            }

            int quantidadeQuestoes = (int)nudQtdeDuplicidade.Value;

            var random = new Random();
            var questoesSorteadas = questoesFiltradas.OrderBy(q => random.Next()).Take(quantidadeQuestoes).ToList();

            listDuplicidadeQuestao.DataSource = questoesSorteadas;
            listDuplicidadeQuestao.DisplayMember = "Enunciado";
        }

        private void chkIncluirTodasMaterias_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDuplicadoRecuperacao.Checked)
            {
                cmbDuplicidadeMateria.DataSource = null;
                cmbDuplicidadeMateria.Text = "Teste de Recuperação";
            }
            else
            {
                cmbDuplicidadeMateria.SelectedIndex = -1;
                AtualizarMaterias();
            }

            cmbDuplicidadeMateria.Enabled = !chkDuplicadoRecuperacao.Checked;
            AtualizarListaQuestoes();

            if (chkDuplicadoRecuperacao.Checked)
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
            string titulo = txtDuplicacaoTitulo.Text;
            Disciplina disciplinaSelecionada = cmbDuplicacaoDisciplina.SelectedItem as Disciplina;
            Materia materiaselecionada = cmbDuplicidadeMateria.SelectedItem as Materia;

            List<Questao> questoesSelecionadas = listDuplicidadeQuestao.Items.OfType<Questao>().ToList();

            Teste = new Teste(titulo, disciplinaSelecionada, materiaselecionada, questoesSelecionadas);

            List<string> erros = Teste.Validar();

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);
                DialogResult = DialogResult.None;
                return;
            }

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
