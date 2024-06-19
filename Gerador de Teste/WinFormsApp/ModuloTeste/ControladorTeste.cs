using WinFormsApp.Compartilhado;
using WinFormsApp.Modulo_disciplina;
using WinFormsApp.ModuloMateria;
using WinFormsApp.ModuloQuestao;

namespace WinFormsApp.ModuloTeste
{
    public class ControladorTeste : ControladorBase, IControladorVisualizavel, IControladorDuplicavel, IControladorGeraPdf
    {
        private TabelaTesteControl TabelaTeste;
        private IRepositorioTeste repositorioTeste;
        private IRepositorioMateria repositorioMateria;
        private IRepositorioDisciplina repositorioDisciplina;
        private IRepositorioQuestao repositorioQuestao;

        public ControladorTeste(IRepositorioTeste repositorioTeste, IRepositorioMateria repositorioMateria, IRepositorioDisciplina repositorioDisciplina, IRepositorioQuestao repositorioQuestao)
        {
            this.repositorioTeste = repositorioTeste;
            this.repositorioMateria = repositorioMateria;
            this.repositorioDisciplina = repositorioDisciplina;
            this.repositorioQuestao = repositorioQuestao;
        }

        public override string TipoCadastro { get { return "Teste"; } }
        public override string ToolTipAdicionar { get { return "Cadastrar um novo Teste"; } }
        public override string ToolTipEditar { get { return "Editar um Teste existente"; } }
        public override string ToolTipExcluir { get { return "Excluir um Teste existente"; } }
        public string ToolTipVisualizar { get { return "Visualizar Teste"; } }
        public string ToolTipDuplicar { get { return "Duplicar Teste"; } }
        public string ToolTipGeradorPDFTeste { get { return "Gerar PDF Teste"; } }
        public string ToolTipGeradorPDFGabarito { get { return "Gerar PDF Gabarito do Teste"; } }

        public override void Adicionar()
        {        
            TelaTesteForm telaTeste = new TelaTesteForm(
                repositorioDisciplina.SelecionarTodos(),
                repositorioMateria.SelecionarTodos(),
                repositorioQuestao.SelecionarTodos()
             
            );
                              
            DialogResult resultado = telaTeste.ShowDialog();
           
            if (resultado != DialogResult.OK)
                return;      

            Teste novoTeste = telaTeste.Teste;
            
            if (repositorioTeste.SelecionarTodos().Any(t => t.Titulo.Equals(novoTeste.Titulo.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show(
                    $"Já existe um teste com o título \"{novoTeste.Titulo}\".",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            repositorioTeste.Cadastrar(novoTeste);

            CarregarTestes();

            TelaPrincipalForm
               .Instancia
               .AtualizarRodape($"O registro do teste \"{novoTeste.Titulo}\" foi criado com sucesso!");      
        }

        public override void Editar()
        {
            int idSelecionado = TabelaTeste.ObterRegistroSelecionado();

            Teste testeSelecionado = repositorioTeste.SelecionarPorId(idSelecionado);

            if (testeSelecionado == null)
            {
                MessageBox.Show(
                    "Não é possível realizar esta ação sem um registro selecionado.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            TelaTesteForm telaTeste = new TelaTesteForm(
                 repositorioDisciplina.SelecionarTodos(),
                 repositorioMateria.SelecionarTodos(),
                 repositorioQuestao.SelecionarTodos()
               )
                 {
                 Teste = testeSelecionado
                 };
             
            DialogResult resultado = telaTeste.ShowDialog();

            if (resultado != DialogResult.OK)
                return;

            Teste testeEditado = telaTeste.Teste;

            if (repositorioTeste.SelecionarTodos().Any(t => t.Titulo.Equals(testeEditado.Titulo.Trim(), StringComparison.OrdinalIgnoreCase) && t.Id != testeSelecionado.Id))
            {
                MessageBox.Show(
                    $"Já existe um teste com o título \"{testeEditado.Titulo}\".",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            repositorioTeste.Editar(testeSelecionado.Id, testeEditado);

            CarregarTestes();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{testeEditado.Titulo}\" foi editado com sucesso!");
        }

        public override void Excluir()
        {
            int idSelecionado = TabelaTeste.ObterRegistroSelecionado();

            Teste testeSelecionado = repositorioTeste.SelecionarPorId(idSelecionado);

            if (testeSelecionado == null)
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
                 $"Você deseja realmente excluir o registro \"{testeSelecionado.Titulo}\"?",
                 "Confirmar Exclusão",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Warning
             );

            if (resultado != DialogResult.Yes)
                return;

            repositorioTeste.Excluir(testeSelecionado.Id);

            CarregarTestes();

            TelaPrincipalForm
              .Instancia
              .AtualizarRodape($"O registro \"{testeSelecionado.Titulo}\" foi excluído com sucesso!");
        }

        private void CarregarTestes()
        {
            List<Teste> testes = repositorioTeste.SelecionarTodos();
            TabelaTeste.AtualizarRegistros(testes);
        }

        public override UserControl ObterListagem()
        {
            if (TabelaTeste == null)
                TabelaTeste = new TabelaTesteControl();

            CarregarTestes();
            return TabelaTeste;
        }

        public void VisualizarTeste()
        {
            int idSelecionado = TabelaTeste.ObterRegistroSelecionado();

            Teste testeSelecionado = repositorioTeste.SelecionarPorId(idSelecionado);

            if (testeSelecionado == null)
            {
                MessageBox.Show(
                    "Não é possível realizar esta ação sem um registro selecionado.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            TelaVisualizaTesteForm telaVisualizar = new TelaVisualizaTesteForm(testeSelecionado);

            DialogResult resultado = telaVisualizar.ShowDialog();

            if (resultado != DialogResult.OK)
                return;
        }

        public void DuplicarTeste()
        {
            int idSelecionado = TabelaTeste.ObterRegistroSelecionado();

            Teste testeSelecionado = repositorioTeste.SelecionarPorId(idSelecionado);

            if (testeSelecionado == null)
            {
                MessageBox.Show(
                    "Não é possível realizar esta ação sem um registro selecionado.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            TelaDuplicaTesteForm telaDuplica = new TelaDuplicaTesteForm
                (
                    testeSelecionado,
                    repositorioDisciplina.SelecionarTodos(),
                    repositorioMateria.SelecionarTodos(),
                    repositorioQuestao.SelecionarTodos()
                ) ;
            DialogResult resultadoduplica = telaDuplica.ShowDialog();

            if (resultadoduplica != DialogResult.OK)
                return;

            Teste novoTesteduplicado = telaDuplica.teste;

            repositorioTeste.Cadastrar(novoTesteduplicado);

            CarregarTestes();

            TelaPrincipalForm
               .Instancia
               .AtualizarRodape($"O registro do teste \"{novoTesteduplicado.Titulo}\" foi criado com sucesso!");

            if (resultadoduplica != DialogResult.OK)
                return;
        }        

        public void GerarGabaritoPDF()
        {
            int idSelecionado = TabelaTeste.ObterRegistroSelecionado();

            Teste testeSelecionado = repositorioTeste.SelecionarPorId(idSelecionado);

            string caminho = $"C:\\temp\\GeradorDeTestes\\gabarito {testeSelecionado.Titulo}.pdf";

            GerarPdf gerarGabarito = new GerarPdf();
            gerarGabarito.GerarPdfGabarito(testeSelecionado, caminho);

            TelaPrincipalForm
            .Instancia
            .AtualizarRodape($"O gabarito do teste foi gerado com sucesso!");

        }

        public void GerarTestePDF()
        {           
            int idSelecionado = TabelaTeste.ObterRegistroSelecionado();

            Teste testeSelecionado = repositorioTeste.SelecionarPorId(idSelecionado);

            string caminho = $"C:\\temp\\GeradorDeTestes\\{testeSelecionado.Titulo}.pdf";            

            GerarPdf gerarPdf = new GerarPdf();
            gerarPdf.GerarPdfTeste(testeSelecionado, caminho);

            TelaPrincipalForm
             .Instancia
             .AtualizarRodape($"O teste foi gerado com sucesso!");
        }
    }
}
