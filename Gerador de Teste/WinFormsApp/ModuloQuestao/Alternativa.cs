using WinFormsApp.Compartilhado;

namespace WinFormsApp.ModuloQuestao
{
    public class Alternativa : EntidadeBase
    {
        
        public string Texto { get; set; }
        public bool Correto {  get; set; }

        public Alternativa() { }

        public Alternativa(string texto, bool correto)
        {
            Texto = texto;
            Correto = correto;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Alternativa alternativa = (Alternativa)novoRegistro;

            Texto = alternativa.Texto;
            Correto = alternativa.Correto;

        }

        public override List<string> Validar()
        {
            throw new NotImplementedException();
        }
    }
}
