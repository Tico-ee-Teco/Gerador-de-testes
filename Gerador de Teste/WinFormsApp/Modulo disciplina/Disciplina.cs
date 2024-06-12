using FestasInfantis.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp.Modulo_disciplina
{
    public class Disciplina : EntidadeBase
    {
        public string Nome { get; set; }
       

        public Disciplina(string nome)
        {

            Nome = nome;
          
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Nome.Trim()))
                erros.Add("O campo \"Nome\" é obrigatório");

        

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Disciplina novaDisciplina = (Disciplina)novoRegistro;

            Nome = novaDisciplina.Nome;
            
        }

        public override string ToString()
        {
            return $"Disciplina: {Nome}";
        }
    }
}
