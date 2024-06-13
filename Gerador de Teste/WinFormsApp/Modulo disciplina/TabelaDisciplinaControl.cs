using WinFormsApp.Compartilhado;

namespace WinFormsApp.Modulo_disciplina
{
    public partial class TabelaDisciplinaControl : UserControl
    {
        public TabelaDisciplinaControl()
        {
            InitializeComponent();

            grid.Columns.AddRange(ObterColunas());

            grid.ConfigurarGridSomenteLeitura();
            grid.ConfigurarGridZebrado();
           
        }

        public void AtualizarRegistros(List<Disciplina> disciplinas)
        {
            grid.Rows.Clear();

            foreach (Disciplina i in disciplinas)
            {
                grid.Rows.Add(
                    i.Id.ToString(),
                    i.Nome                                  
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
            };
        }
    }
}
