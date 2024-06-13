using WinFormsApp.Compartilhado;

namespace WinFormsApp.ModuloQuestao
{
    public class Alternativa : EntidadeBase
    {
        
        public string Texto { get; set; }
        public bool Correto {  get; set; }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            throw new NotImplementedException();
        }

        public override List<string> Validar()
        {
            throw new NotImplementedException();
        }
    }
}
