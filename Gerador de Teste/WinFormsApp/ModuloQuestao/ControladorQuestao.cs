using WinFormsApp.Compartilhado;
using WinFormsApp.Modulo_disciplina;
using WinFormsApp.ModuloMateria;

namespace WinFormsApp.ModuloQuestao
{
    public class ControladorQuestao : ControladorBase
    {
        private TabelaQuestaoControl tabelaQuestao;
        private IRepositorioQuestao repositorioQuestao;
        private IRepositorioDisciplina repositorioDisciplina;
        private IRepositorioMateria repositorioMateria;
        public override string TipoCadastro { get { return "Questão"; } }

        public override string ToolTipAdicionar { get { return "Cadastrar uma nova Questão"; } }

        public override string ToolTipEditar { get { return "Editar uma Questão existente"; } }

        public override string ToolTipExcluir { get { return "Excluir uma Questão existente"; } }

        public ControladorQuestao(IRepositorioQuestao repositorioQuestao, IRepositorioMateria repositorioMateria)
        {
            this.repositorioQuestao = repositorioQuestao;
            this.repositorioMateria = repositorioMateria;
        }

        public override void Adicionar()
        {
            TelaQuestaoForm telaQuestao = new TelaQuestaoForm(repositorioMateria.SelecionarTodos());

            DialogResult resultado = telaQuestao.ShowDialog();

            if (resultado != DialogResult.OK)
                return;

            Questao novaQuestao = telaQuestao.Questao;

            repositorioQuestao.Cadastrar(novaQuestao);

            CarregarQuestao();

            TelaPrincipalForm
               .Instancia
               .AtualizarRodape($"O registro \"{novaQuestao.Enunciado}\" foi criado com sucesso!");
        }

        public override void Editar()
        {
            TelaQuestaoForm telaQuestao = new TelaQuestaoForm(repositorioMateria.SelecionarTodos());

            int idSelecionado = tabelaQuestao.ObterRegistroSelecionado();

            Questao questaoSelecionada = repositorioQuestao.SelecionarPorId(idSelecionado);

            if (questaoSelecionada == null)
            {
                MessageBox.Show(
                    "Não é possível realizar esta ação sem um registro selecionado.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            telaQuestao.Questao = questaoSelecionada;

            DialogResult resultado = telaQuestao.ShowDialog();

            if (resultado != DialogResult.OK)
                return;

            Questao questaoEditada = telaQuestao.Questao;

            repositorioQuestao.Editar(questaoSelecionada.Id, questaoEditada);

            CarregarQuestao();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{questaoEditada.Enunciado}\" foi editado com sucesso!");
        }

        public override void Excluir()
        {
            TelaQuestaoForm telaQuestaoForm = new TelaQuestaoForm(repositorioMateria.SelecionarTodos());

            int idSelecionado = tabelaQuestao.ObterRegistroSelecionado();

            Questao questaoSelecionada = repositorioQuestao.SelecionarPorId(idSelecionado);

            if (questaoSelecionada == null)
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
                 $"Você deseja realmente excluir o registro \"{questaoSelecionada.Enunciado}\"?",
                 "Confirmar Exclusão",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Warning
             );

            if (resultado != DialogResult.Yes)
                return;

            repositorioQuestao.Excluir(questaoSelecionada.Id);

            CarregarQuestao();

            TelaPrincipalForm
              .Instancia
              .AtualizarRodape($"O registro \"{questaoSelecionada.Enunciado}\" foi excluído com sucesso!");
        }       

        private void CarregarQuestao()
        {
            List<Questao> questoes = repositorioQuestao.SelecionarTodos();

            tabelaQuestao.AtualizarRegistros(questoes);
        }

        public override UserControl ObterListagem()
        {
            if (tabelaQuestao == null)
                tabelaQuestao = new TabelaQuestaoControl();

            CarregarQuestao();

            return tabelaQuestao;
        }
    }
}
