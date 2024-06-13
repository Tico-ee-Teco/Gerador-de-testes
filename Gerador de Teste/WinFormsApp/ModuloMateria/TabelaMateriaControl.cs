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

namespace WinFormsApp.ModuloMateria
{
    public partial class TabelaMateriaControl : UserControl
    {
        public TabelaMateriaControl()
        {
            InitializeComponent();

            grid.Columns.AddRange(ObterColunas());

            grid.ConfigurarGridSomenteLeitura();
            grid.ConfigurarGridZebrado();
        }

        public void AtualizarRegistros(List<Materia> materias)
        {
            grid.Rows.Clear();

            foreach (Materia i in materias)
            {
                grid.Rows.Add(
                    i.Id.ToString(),
                    i.Nome,
                    i.Disciplina,
                    i.Serie
                    );
            }
        }

        public int ObterRegistroSelecionado()
        {
            return grid.SelecionarId();

        }

        private DataGridViewColumn[] ObterColunas()
        {
            return new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome" },
                 new DataGridViewTextBoxColumn { DataPropertyName = "Disciplina", HeaderText = "Disciplina" },
                 new DataGridViewTextBoxColumn {DataPropertyName = "Serie", HeaderText = "Serie" }

            };
        }       
    }
}
