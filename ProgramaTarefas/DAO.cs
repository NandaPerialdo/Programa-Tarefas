using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MySql.Data;//imports para usar o my sql
using MySql.Data.MySqlClient;
using Mysqlx.Crud;

namespace ProgramaTarefas
{
    class DAO
    {
        public MySqlConnection conexao; //atribuindo os metodos da classe
                                        //MySqlConnection para a variavel conexao
        public string dados;
        public string sql;
        public string resultado;
        public string nome;//declarando as variaveis que serao usadas pra preencher o banco
        public string telefone;
        public string email;
        public string datanasc;
        public string login;
        public string senha;
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

        public void InserirUsuario (string nome, string telefone, string email, string datanasc, string login, string senha)
        {
            try
            {
                dados = "('','" + nome + "', '" + telefone + "','" + email + "','" + datanasc + "','" + login + "','" + senha + "')";
                sql = "insert into usuario(codigo, nome, telefone, email, datanasc, login, senha) values" + dados;//essa linha representa entre "" o que será executado dentro do banco de dados
                                                                                                                  //na linha de cima, dentro da variavel "dados" serao preenchidos os dados a serem
                                                                                                                  //inseridos, antes de executar a linha de codigo no banco de dados

                MySqlCommand conn = new MySqlCommand(sql, conexao);// preparando a execuçao no banco
                resultado = "" + conn.ExecuteNonQuery();//executa o comando dentro do banco de dados (ctrl + enter)
                Console.WriteLine(resultado + "Linha afetada");
            }//fim do try
            catch (Exception erro)//caso ocorra erro na execução
            {
                Console.WriteLine("Erro! Algo deu errado :(\n\n\n" + erro);
            }//fim do catch
        }//fim do metodo inserir usuario

    }//fim da classe
}//fim do projeto
