using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

            AtualizarMaterias();
            AtualizarListaQuestoes();
        }

        private void CmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarMaterias();
            AtualizarListaQuestoes();
        
        }
        private void CmbMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
        AtualizarListaQuestoes();
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
            CmbMateria.Enabled = !chkProvaRecuperacao.Checked;
            AtualizarListaQuestoes();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string titulo = txtTitulo.Text;
            Disciplina disciplinaSelecionada = CmbDisciplina.SelectedItem as Disciplina;
            Materia materiaselecionada = CmbMateria.SelectedItem as Materia;
            List<Questao> questoesSelecionadas = listQuestao.Items.OfType<Questao>().ToList();
            //bool provarecuperaçao = chkProvaRecuperacao.Checked;

            //if (provarecuperaçao)
            //    materiaselecionada = null;
            
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
