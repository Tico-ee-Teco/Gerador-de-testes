using WinFormsApp.Compartilhado;

namespace WinFormsApp.ModuloQuestao
{
    public partial class TabelaQuestaoControl : UserControl
    {
        public TabelaQuestaoControl()
        {
            InitializeComponent();

            grid.Columns.AddRange(ObterColunas());

            grid.ConfigurarGridSomenteLeitura();
            grid.ConfigurarGridZebrado();
        }

        public void AtualizarRegistros(List<Questao> questoes)
        {
            grid.Rows.Clear();

            foreach (Questao q in questoes)
            {
                grid.Rows.Add(
                    q.Id.ToString(),
                    q.Enunciado,
                    q.Materia,
                    q.Resposta
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
                new DataGridViewTextBoxColumn { DataPropertyName = "Enunciado", HeaderText = "Enunciado" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Materia", HeaderText = "Materia" },
                new DataGridViewTextBoxColumn { DataPropertyName = "RespostaCorreta", HeaderText = "Resposta"}
            };
        }


    }
}
