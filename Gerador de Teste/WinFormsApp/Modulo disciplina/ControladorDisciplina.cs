using WinFormsApp.Compartilhado;
using WinFormsApp.ModuloMateria;

namespace WinFormsApp.Modulo_disciplina
{
    public class ControladorDisciplina : ControladorBase
    {
        private TabelaDisciplinaControl TabelaDisciplina;

        private IRepositorioDisciplina repositorioDisciplina;

        public override string TipoCadastro { get { return "Disciplina"; } }

        public override string ToolTipAdicionar { get { return "Cadastrar uma nova Disciplina"; } }

        public override string ToolTipEditar { get { return "Editar uma Disciplina existente"; } }

        public override string ToolTipExcluir { get { return "Excluir uma Disciplina existente"; } }

        public ControladorDisciplina(IRepositorioDisciplina repositorioDisciplina)
        {
            this.repositorioDisciplina = repositorioDisciplina;
        }

        public override void Adicionar()
        {
            TelaDisciplinaForm telaDisciplina = new TelaDisciplinaForm();

            DialogResult resultado = telaDisciplina.ShowDialog();

            if (resultado != DialogResult.OK)
                return;

           Disciplina novadisciplina = telaDisciplina.Disciplina;

            if (repositorioDisciplina.SelecionarTodos().Any(m => m.Nome.Equals(novadisciplina.Nome, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show(
                    $"Já existe uma matéria com o nome \"{novadisciplina.Nome}\".",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            repositorioDisciplina.Cadastrar(novadisciplina);

            CarregarDisciplina();

            TelaPrincipalForm
               .Instancia
               .AtualizarRodape($"O registro Da disciplina \"{novadisciplina.Nome}\" foi criado com sucesso!");
        }

        public override void Editar()
        {
            TelaDisciplinaForm telaDisciplina = new TelaDisciplinaForm();

            int idSelecionado = TabelaDisciplina.ObterRegistroSelecionado();

            Disciplina DisciplinaSelecionada = repositorioDisciplina.SelecionarPorId(idSelecionado);

            if (DisciplinaSelecionada == null)
            {
                MessageBox.Show(
                    "Não é possível realizar esta ação sem um registro selecionado.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            telaDisciplina.Disciplina = DisciplinaSelecionada;

            DialogResult resultado = telaDisciplina.ShowDialog();

            if (resultado != DialogResult.OK)
                return;

            Disciplina DisciplinaEditada = telaDisciplina.Disciplina;

            repositorioDisciplina.Editar(DisciplinaSelecionada.Id, DisciplinaEditada);

            CarregarDisciplina();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{DisciplinaEditada.Nome}\" foi editado com sucesso!");
        }

        public override void Excluir()
        {
           TelaDisciplinaForm telaDisciplinaForm = new TelaDisciplinaForm();

            int idSelecionado = TabelaDisciplina.ObterRegistroSelecionado();

            Disciplina DisciplinaSelecionada = repositorioDisciplina.SelecionarPorId(idSelecionado);

            if (DisciplinaSelecionada == null)
            {
                MessageBox.Show(
                    "Não é possível realizar esta ação sem um registro selecionado.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DialogResult resultado = MessageBox.Show(
                 $"Você deseja realmente excluir o registro \"{DisciplinaSelecionada.Nome}\"?",
                 "Confirmar Exclusão",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Warning
             );

            if (resultado != DialogResult.Yes)
                return;

            repositorioDisciplina.Excluir(DisciplinaSelecionada.Id);

           CarregarDisciplina();

            TelaPrincipalForm
              .Instancia
              .AtualizarRodape($"O registro \"{DisciplinaSelecionada.Nome}\" foi excluído com sucesso!");
        }

        private void CarregarDisciplina()
        {
            List<Disciplina> disciplinas = repositorioDisciplina.SelecionarTodos();
            TabelaDisciplina.AtualizarRegistros(disciplinas);
        }

        public override UserControl ObterListagem()
        {
            if (TabelaDisciplina == null)
                TabelaDisciplina = new TabelaDisciplinaControl();

            CarregarDisciplina();

            return TabelaDisciplina;
        }
    }
}
