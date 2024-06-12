using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp.Modulo_disciplina
{

    public partial class TelaDisciplinaForm : Form
    {
        private Disciplina disciplina;
        public Disciplina Disciplina
        {
            get
            {
                return Disciplina;
            }
            set
            {
                TxtID.Text = value.Id.ToString();
                TxtNome.Text = value.Nome;
               
            }

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

            string nome = TxtNome.Text;
           

            Disciplina = new Disciplina(nome);

            List<string> erros = Disciplina.Validar();

            if (erros.Count > 0)
            {
                //TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);
                //DialogResult = DialogResult.None;
            }
        }


        public TelaDisciplinaForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
 
