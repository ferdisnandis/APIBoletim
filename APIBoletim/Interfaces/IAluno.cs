using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBoletim.Domains
{
    interface IAluno
    {
        List<Aluno> ListarTodos();
        Aluno BuscarPorID(int id);
        Aluno Cadastrar(Aluno a);
        Aluno Alterar(Aluno a);
        void Excluir(int id);
    }
}
