using FestasInfantis.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp.Modulo_disciplina;

namespace WinFormsApp.ModuloMateria
{
    public partial class TelaMateriaForm : Form
    {
        private Materia materia;
        private ContextoDados contexto;

        
        public TelaMateriaForm()
        {
            InitializeComponent();
        }

       
        public TelaMateriaForm(ContextoDados contextoDados) : this()
        {
            contexto = contextoDados;
           
            CmbDisciplina.DataSource = contexto.Disciplinas;
            CmbDisciplina.DisplayMember = "Nome";
        }

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
                if (value.Serie == "Serie1")
                    RB1Serie.Checked = true;
                else if (value.Serie == "Serie2")
                    RB2Serie.Checked = true;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string nome = TxtNome.Text;
            Disciplina disciplinaSelecionada = (Disciplina)CmbDisciplina.SelectedItem;
            string serie = RB1Serie.Checked ? "Serie1" : RB2Serie.Checked ? "Serie2" : string.Empty;

            materia = new Materia(nome, disciplinaSelecionada, serie);

            List<string> erros = materia.Validar();

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);
                DialogResult = DialogResult.None;
                return;
            }

            if (!contexto.Materias.Contains(materia))
                contexto.Materias.Add(materia);

            contexto.Gravar();
            DialogResult = DialogResult.OK;
        }

        //public partial class TelaMateriaForm : Form
        //{
        //    private Materia materia;
        //    private ContextoDados contexto;

        //    public TelaMateriaForm(ContextoDados contexto)
        //    {

        //        CmbDisciplina.DataSource = contexto.Disciplinas;
        //        CmbDisciplina.DisplayMember = "Nome";

        //    }

        //    public Materia Materia
        //    {
        //        get
        //        {
        //            return materia;
        //        }
        //        set
        //        {
        //            materia = value;
        //            TxtID.Text = value.Id.ToString();
        //            TxtNome.Text = value.Nome;
        //            CmbDisciplina.SelectedItem = value.Disciplina;
        //            if (value.Serie == "1 Serie")
        //                RB1Serie.Checked = true;
        //            else if (value.Serie == "2 Serie")
        //                RB2Serie.Checked = true;
        //        }
        //    }

        //    private void btnGravar_Click(object sender, EventArgs e)
        //    {
        //        string nome = TxtNome.Text;
        //        Disciplina disciplinaSelecionada = (Disciplina)CmbDisciplina.SelectedItem;
        //        string serie = RB1Serie.Checked ? "1 Serie" : RB2Serie.Checked ? "2 Serie" : string.Empty;

        //        materia = new Materia(nome, disciplinaSelecionada, serie);

        //        List<string> erros = materia.Validar();

        //        if (erros.Count > 0)
        //        {
        //            TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);
        //            DialogResult = DialogResult.None;
        //            return;
        //        }

        //        if (!contexto.Materias.Contains(materia))
        //            contexto.Materias.Add(materia);

        //        contexto.Gravar();
        //        DialogResult = DialogResult.OK;
        //    }

        //    public TelaMateriaForm()
        //    {
        //        InitializeComponent();
        //    }


    }
}
