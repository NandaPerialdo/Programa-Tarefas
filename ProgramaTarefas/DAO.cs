using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;//imports para usar o my sql
using MySql.Data.MySqlClient;


namespace ProgramaTarefas
{
    class DAO
    {
        public MySqlConnection conexao; //atribuindo os metodos da classe
                                        //MySqlConnection para a variavel conexao
        public DAO()
        {
            conexao = new MySqlConnection("server=localhost;DataBase=Pessoa;Uid=root;Password="); //estabelecendo conexao da classe MySqlConnection com a variavel conexao 
            try // tratar o caso de se a conexao nao for completa
            {
                conexao.Open();//abrindo a conexao com o banco de dados
                Console.WriteLine("Conectado com sucesso!");
            }
            catch (Exception erro) //caso a conexao nao seja bem sucedida...
            {
                Console.WriteLine("Algo deu errado! Verifique os dados de conexão!\n\n" + erro); //exibindo uma mensagem legivel pro usuario + o erro para ser interpretado pelo tecnico
                conexao.Close();//fechar a conexao com o banco de dados pra poder realizar outras operaçoes
            }//fim do try catch
        }//fim do metodo DAO

        public void InserirUsuario (string nome,  )


    }//fim da classe
}//fim do projeto
