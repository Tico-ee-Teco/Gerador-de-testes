
using WinFormsApp.Compartilhado;
using WinFormsApp.Modulo_disciplina;
using WinFormsApp.ModuloMateria;

namespace WinFormsApp
{
    public partial class TelaPrincipalForm : Form
    {
        ControladorBase controlador;

        ContextoDados contexto;

        IRepositorioDisciplina repositorioDisciplina;
        IRepositorioMateria repositorioMateria;

        public static TelaPrincipalForm Instancia { get; private set; }

        public TelaPrincipalForm()
        {
            InitializeComponent();

            lblTipoCadastro.Text = string.Empty;
            Instancia = this;

            contexto = new ContextoDados(carregarDados: true);
            repositorioDisciplina = new RepositorioDisciplinaEmArquivo(contexto);
            repositorioMateria = new RepositorioMateriaEmArquivo(contexto);

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

            ConfigurarToolTips(controladorSelecionado);
        }

        private void ConfigurarToolTips(ControladorBase controladorSelecionado)
        {
            btnAdicionar.ToolTipText = controladorSelecionado.ToolTipAdicionar;
            btnEditar.ToolTipText = controladorSelecionado.ToolTipEditar;
            btnExcluir.ToolTipText = controladorSelecionado.ToolTipExcluir;
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
