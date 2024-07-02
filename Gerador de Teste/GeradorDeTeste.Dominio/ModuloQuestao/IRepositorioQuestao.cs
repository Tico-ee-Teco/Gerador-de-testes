﻿namespace WinFormsApp.Dominio.ModuloQuestao
{
    public interface IRepositorioQuestao
    {
        void Cadastrar(Questao novaQuestao);
        bool Editar(int id, Questao questaoSelecionada);
        bool Excluir(int id);
        Questao SelecionarPorId(int idSelecionado);
        List<Questao> SelecionarTodos();
        bool EstaEmTeste(int idQuestao);
        void Atualizar(Questao questaoAtualizada);
    }
}
