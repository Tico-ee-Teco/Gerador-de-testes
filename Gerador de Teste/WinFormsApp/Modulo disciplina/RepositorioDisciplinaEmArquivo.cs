using FestasInfantis.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WinFormsApp.Modulo_disciplina.IRepositorioDisciplina;

namespace WinFormsApp.Modulo_disciplina
{
    public class RepositorioDisciplinaEmArquivo : RepositorioBaseEmArquivo<Disciplina>,IRepositorioDisciplina
    {
        public RepositorioDisciplinaEmArquivo(ContextoDados contexto) : base(contexto)
        {

        }
        protected override List<Disciplina> ObterRegistros()
        {
            return contexto.Disciplinas;
        }


    }
}
        
   

