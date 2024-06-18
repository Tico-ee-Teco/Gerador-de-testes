
using WinFormsApp.Compartilhado;
using WinFormsApp.Modulo_disciplina;

namespace WinFormsApp.ModuloMateria
{
    public class ControladorMateria : ControladorBase
    {
        private TabelaMateriaControl TabelaMateria;
        private IRepositorioMateria repositorioMateria;
        private IRepositorioDisciplina repositorioDisciplina;       
        public ControladorMateria(IRepositorioMateria repositorioMateria, IRepositorioDisciplina repositorioDisciplina)
        {
            this.repositorioMateria = repositorioMateria;
            this.repositorioDisciplina = repositorioDisciplina;           
        }
        public override string TipoCadastro { get { return "Matéria"; } }
        public override string ToolTipAdicionar { get { return "Cadastrar uma nova Matéria"; } }
        public override string ToolTipEditar { get { return "Editar uma Matéria existente"; } }
        public override string ToolTipExcluir { get { return "Excluir uma Matéria existente"; } }

        public override void Adicionar()
        {
            TelaMateriaForm telaMateria = new TelaMateriaForm(repositorioDisciplina.SelecionarTodos());

            DialogResult resultado = telaMateria.ShowDialog();

            if (resultado != DialogResult.OK)
                return;

            Materia novaMateria = telaMateria.Materia;

            if (repositorioMateria.SelecionarTodos().Any(m => m.Nome.Equals(novaMateria.Nome, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show(
                    $"Já existe uma matéria com o nome \"{novaMateria.Nome}\".",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            repositorioMateria.Cadastrar(novaMateria);

            CarregarMaterias();

            TelaPrincipalForm
               .Instancia
               .AtualizarRodape($"O registro da matéria \"{novaMateria.Nome}\" foi criado com sucesso!");
        }

        public override void Editar()
        {
            int idSelecionado = TabelaMateria.ObterRegistroSelecionado();

            Materia materiaSelecionada = repositorioMateria.SelecionarPorId(idSelecionado);

            if (materiaSelecionada == null)
            {
                MessageBox.Show(
                    "Não é possível realizar esta ação sem um registro selecionado.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            TelaMateriaForm telaMateria = new TelaMateriaForm(repositorioDisciplina.SelecionarTodos())
            {
                Materia = materiaSelecionada
            };

            DialogResult resultado = telaMateria.ShowDialog();

            if (resultado != DialogResult.OK)
                return;

            Materia materiaEditada = telaMateria.Materia;

            if (repositorioMateria.SelecionarTodos().Any(m => m.Nome.Equals(materiaEditada.Nome, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show(
                    $"Já existe uma matéria com o nome \"{materiaEditada.Nome}\".",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            repositorioMateria.Editar(materiaSelecionada.Id, materiaEditada);

            CarregarMaterias();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{materiaEditada.Nome}\" foi editado com sucesso!");
        }
        public override void Excluir()
        {
            int idSelecionado = TabelaMateria.ObterRegistroSelecionado();

            Materia materiaSelecionada = repositorioMateria.SelecionarPorId(idSelecionado);

            if (materiaSelecionada == null)
            {
                MessageBox.Show(
                    "Não é possível realizar esta ação sem um registro selecionado.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (repositorioMateria.ExisteTesteComMateria(materiaSelecionada.Id))
            {
                MessageBox.Show(
                    "Não é possível excluir esta matéria pois ela está associada a um ou mais testes.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            DialogResult resultado = MessageBox.Show(
                 $"Você deseja realmente excluir o registro \"{materiaSelecionada.Nome}\"?",
                 "Confirmar Exclusão",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Warning
                );

            if (resultado != DialogResult.Yes)
                return;

            repositorioMateria.Excluir(materiaSelecionada.Id);

            CarregarMaterias();

            TelaPrincipalForm
              .Instancia
              .AtualizarRodape($"O registro \"{materiaSelecionada.Nome}\" foi excluído com sucesso!");
        }

        private void CarregarMaterias()
        {
            List<Materia> materias = repositorioMateria.SelecionarTodos();
            TabelaMateria.AtualizarRegistros(materias);
        }

        public override UserControl ObterListagem()
        {
            if (TabelaMateria == null)
                TabelaMateria = new TabelaMateriaControl();

            CarregarMaterias();
            return TabelaMateria;
        }
    }
}
