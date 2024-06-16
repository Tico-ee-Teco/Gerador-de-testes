using WinFormsApp.Compartilhado;

namespace WinFormsApp.ModuloTeste
{
    public class ControladorTeste : ControladorBase
    {
        private IRepositorioTeste repositorioTeste;
        public override string TipoCadastro { get { return "Teste"; } }

        public override string ToolTipAdicionar { get { return "Cadastrar uma novo Teste"; } }

        public override string ToolTipEditar { get { return "Editar um Teste existente"; } }

        public override string ToolTipExcluir { get { return "Excluir um Teste existente"; } }

        public ControladorTeste(IRepositorioTeste repositorioTeste)
        {
            this.repositorioTeste = repositorioTeste;
        }

        public override void Adicionar()
        {
            throw new NotImplementedException();
        }

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }

        public override UserControl ObterListagem()
        {
            throw new NotImplementedException();
        }
    }
}
