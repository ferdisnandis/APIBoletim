using APIBoletim.Context;
using APIBoletim.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIBoletim.Repositories
{
    public class AlunoRepository : IAluno
    {
        //Chamamos nosso contexto de conexão
        BoletimContext conexao = new BoletimContext();

        //Chamamos a classe que permite colocar consultas (Query) de banco
        SqlCommand cmd = new SqlCommand();
        public Aluno Alterar(Aluno a)
        {
            //Abrir a conexão
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE Aluno SET " +
            "Nome = @nome, " +
            "RA = @ra, " +
            "Idade = @idade WHERE IdAluno =  @id";

            cmd.Parameters.AddWithValue("@id", a.IdAluno);
            cmd.Parameters.AddWithValue("@nome", a.Nome);
            cmd.Parameters.AddWithValue("@ra", a.RA );
            cmd.Parameters.AddWithValue("@idade", a.Idade);


            cmd.ExecuteNonQuery();
            //Fechar a conexão
            conexao.Desconectar();

            return a;

        }

        public Aluno BuscarPorID(int id)
        {
            //Abrir a conexão
            cmd.Connection = conexao.Conectar();

            //Atribuir nossa conexão
            cmd.CommandText = "SELECT * FROM ALUNO WHERE IdAluno = @id";

            //Dizemos quem é o @id
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            Aluno a = new Aluno();

            while (dados.Read())
            {
                a.IdAluno = Convert.ToInt32(dados.GetValue(0));
                a.Nome = dados.GetValue(1).ToString();
                a.RA = dados.GetValue(2).ToString();
                a.Idade = Convert.ToInt32(dados.GetValue(3));
            }

            //Fechar a conexão
            conexao.Desconectar();

            return a;
        }

        public Aluno Cadastrar(Aluno a)
        {
            //Abrir conexão
            cmd.Connection = conexao.Conectar();

            //Cadastrar
            cmd.CommandText = "INSERT INTO Aluno " +
                "(Nome, Ra, Idade)" +
                "VALUES" +
                "(@nome, @ra, @idade)";
            cmd.Parameters.AddWithValue("@nome", a.Nome);
            cmd.Parameters.AddWithValue("@ra", a.RA);
            cmd.Parameters.AddWithValue("@idade", a.Idade);

            cmd.ExecuteNonQuery();

            //Fechar conexão
            conexao.Desconectar();

            return a;
        }

        public void Excluir(int id)
        {
            //Abrir conexão
            cmd.Connection = conexao.Conectar();

            //Deletar
            cmd.CommandText = "DELETE FROM Aluno " +
                "WHERE IdAluno = @id";

            //Procurar pelo Id
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            //Fechar Conexão
            conexao.Desconectar();
        } 

        public List<Aluno> ListarTodos()
        {

            //Abrir a conexão
            cmd.Connection = conexao.Conectar();

            //Atribuir nossa conexão
            cmd.CommandText = "SELECT * FROM ALUNO";

            //Ler dados
            SqlDataReader dados = cmd.ExecuteReader();

            //Listar dados
            List<Aluno> alunos = new List<Aluno>();

            //Criar laço para ler as linhas
            while (dados.Read())
            {
                alunos.Add(
                    new Aluno()
                    {
                        IdAluno = Convert.ToInt32(dados.GetValue(0)),
                        Nome = dados.GetValue(1).ToString(),
                        RA = dados.GetValue(2).ToString(),
                        Idade = Convert.ToInt32(dados.GetValue(3)),
                    }
                );
            }

            //Fechar a conexão
            conexao.Desconectar();

            return alunos;
        }
    }
}
