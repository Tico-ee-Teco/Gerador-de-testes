using WinFormsApp.Compartilhado;

namespace WinFormsApp.ModuloTeste
{
    public partial class TabelaTesteControl : UserControl
    {
        public TabelaTesteControl()
        {
            InitializeComponent();

            grid.Columns.AddRange(ObterColunas());

            grid.ConfigurarGridSomenteLeitura();
            grid.ConfigurarGridZebrado();
        }
        //public void AtualizarRegistros(List<Teste> testes)
        //{
        //    grid.Rows.Clear();

        //    foreach (Teste t in testes)
        //    {

        //        string materiaNome = t.Materia != null ? t.Materia.Nome : "Prova de Recuperação";

        //        grid.Rows.Add(
        //            t.Id.ToString(),
        //            t.Titulo.ToString(),
        //            t.Disciplina.Nome,
        //            materiaNome,
        //            t.QtdeQuestoes
        //        );
        //    }
        //}
        public void AtualizarRegistros(List<Teste> testes)
        {
            grid.Rows.Clear();

            foreach (Teste t in testes)
            {
                string materiaNome = t.Materia != null ? t.Materia.Nome : "Teste de Recuperação";

                grid.Rows.Add(
                    t.Id.ToString(),
                    t.Titulo.ToString(),
                    t.Disciplina.Nome,
                    materiaNome,
                    t.QtdeQuestoes
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
                new DataGridViewTextBoxColumn  {DataPropertyName = "Titulo", HeaderText = "Titulo" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Disciplina", HeaderText = "Disciplina" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Materia", HeaderText = "Materia" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Qtde de Questoes", HeaderText = "Qtde de Questões"}
            };
        }
    }
}
