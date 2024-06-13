using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp.Modulo_disciplina;

namespace WinFormsApp.ModuloMateria
{
   public interface IRepositorioMateria 
    {
        void Cadastrar(Materia NovaMateria);
        bool Editar(int id, Materia MateriaSelecionada);
        bool Excluir(int id);
        Materia SelecionarPorId(int idSelecionado);
        List<Materia> SelecionarTodos();
    }
}
