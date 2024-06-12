using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp.Modulo_disciplina
{
   
        public interface IRepositorioDisciplina

        {
            void Cadastrar(Disciplina NovaDisciplina);
            bool Editar(int id, Disciplina DisciplinaSelecionada);
            bool Excluir(int id);
            Disciplina SelecionarPorId(int idSelecionado);
            List<Disciplina> SelecionarTodos();
        }
    
}
