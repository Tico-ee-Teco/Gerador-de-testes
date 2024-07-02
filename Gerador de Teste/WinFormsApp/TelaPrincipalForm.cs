using WinFormsApp.Compartilhado;
using WinFormsApp.Modulo_disciplina;
using WinFormsApp.ModuloMateria;
using WinFormsApp.ModuloQuestao;
using WinFormsApp.ModuloTeste;

namespace WinFormsApp
{
    public partial class TelaPrincipalForm : Form
    {
        ControladorBase controlador;

        ContextoDados contexto;

        IRepositorioDisciplina repositorioDisciplina;
        IRepositorioMateria repositorioMateria;
        IRepositorioQuestao repositorioQuestao;
        IRepositorioTeste repositorioTeste;

        public static TelaPrincipalForm Instancia { get; private set; }

        public TelaPrincipalForm()
        {
            InitializeComponent();

            lblTipoCadastro.Text = string.Empty;
            Instancia = this;

            contexto = new ContextoDados(carregarDados: true);
            repositorioDisciplina = new RepositorioDisciplinaEmSql();
            repositorioMateria = new RepositorioMateriaEmSql();
            repositorioQuestao = new RepositorioQuestaoEmArquivo(contexto);
            repositorioTeste = new RepositorioTesteEmArquivo(contexto);

        }
        private void disciplinaMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorDisciplina(repositorioDisciplina);

            ConfigurarTelaPrincipal(controlador);
        }
        private void materiaMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorMateria(repositorioMateria, repositorioDisciplina);

            ConfigurarTelaPrincipal(controlador);
        }
        private void testesMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorTeste(repositorioTeste, repositorioMateria, repositorioDisciplina, repositorioQuestao);

            ConfigurarTelaPrincipal(controlador);

        }

        private void quest�esMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorQuestao(repositorioQuestao, repositorioMateria);

            ConfigurarTelaPrincipal(controlador);
        }

        public void AtualizarRodape(string texto)
        {
            statusLabelPrincipal.Text = texto;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            controlador.Adicionar();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            controlador.Editar();
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            if (controlador is IControladorVisualizavel controladorVisualizavel)
                controladorVisualizavel.VisualizarTeste();
        }

        private void btnDuplicar_Click(object sender, EventArgs e)
        {
            if (controlador is IControladorDuplicavel controladorDuplicavel)
                controladorDuplicavel.DuplicarTeste();
        }

        private void btnCriarPdf_Click(object sender, EventArgs e)
        {
            if (controlador is IControladorGeraPdf controladorGeraPdf)
                controladorGeraPdf.GerarTestePDF();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (controlador is IControladorGeraPdf controladorGeraPdf)
                controladorGeraPdf.GerarGabaritoPDF();
        }
    
        private void ConfigurarTelaPrincipal(ControladorBase controladorSelecionado)
        {
            lblTipoCadastro.Text = "Cadastro de " + controladorSelecionado.TipoCadastro;

            ConfigurarToolBox(controladorSelecionado);
            ConfigurarListagem(controladorSelecionado);
        }

        private void ConfigurarToolBox(ControladorBase controladorSelecionado)
        {
            btnAdicionar.Enabled = controladorSelecionado is ControladorBase;
            btnEditar.Enabled = controladorSelecionado is ControladorBase;
            btnExcluir.Enabled = controladorSelecionado is ControladorBase;

            btnVisualizar.Enabled = controladorSelecionado is IControladorVisualizavel;
            btnDuplicar.Enabled = controladorSelecionado is IControladorDuplicavel;
            btnCriarPdf.Enabled = controladorSelecionado is IControladorGeraPdf;
            btnPdfGabarito.Enabled = controladorSelecionado is IControladorGeraPdf;

            ConfigurarToolTips(controladorSelecionado);
        }

        private void ConfigurarToolTips(ControladorBase controladorSelecionado)
        {
            btnAdicionar.ToolTipText = controladorSelecionado.ToolTipAdicionar;
            btnEditar.ToolTipText = controladorSelecionado.ToolTipEditar;
            btnExcluir.ToolTipText = controladorSelecionado.ToolTipExcluir;

            if (controladorSelecionado is IControladorVisualizavel controladorVisualizavel)
                btnVisualizar.ToolTipText = controladorVisualizavel.ToolTipVisualizar;

            if (controladorSelecionado is IControladorDuplicavel controladorDuplicavel)
                btnDuplicar.ToolTipText = controladorDuplicavel.ToolTipDuplicar;

            if (controladorSelecionado is IControladorGeraPdf controladorGeraPdf)
            {
                btnCriarPdf.ToolTipText = controladorGeraPdf.ToolTipGeradorPDFTeste;
                btnPdfGabarito.ToolTipText = controladorGeraPdf.ToolTipGeradorPDFGabarito;
            }
        }

        private void ConfigurarListagem(ControladorBase controladorSelecionado)
        {
            UserControl listagemContato = controladorSelecionado.ObterListagem();
            listagemContato.Dock = DockStyle.Fill;

            pnlRegistros.Controls.Clear();
            pnlRegistros.Controls.Add(listagemContato);
        }

       
    }
}
