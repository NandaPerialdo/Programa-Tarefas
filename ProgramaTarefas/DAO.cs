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
        public int[] codigo;
        public string[] nome;//declarando as variaveis que serao usadas pra preencher o banco
        public string[] telefone;
        public string[] email;
        public string[] dtnasc;
        public string[] login;
        public string[] senha;
        public int i;
        public int contador;
        public string[] nomeTarefa;
        public string[] descricaoTarefa;
        public string[] dtTarefa;
        public DAO()
        {
            conexao = new MySqlConnection("server=localhost;DataBase=ProgramaTarefas;Uid=root;Password="); //estabelecendo conexao da classe MySqlConnection com a variavel conexao 
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

        public void InserirUsuario (string nome, string telefone, string email, string dtnasc, string login, string senha)
        {
            try
            {
                dados = "('','" + nome + "', '" + telefone + "','" + email + "','" + dtnasc + "','" + login + "','" + senha + "')";
                sql = "insert into usuario(codigo, nome, telefone, email, dtnasc, login, senha) values" + dados;//essa linha representa entre "" o que será executado dentro do banco de dados
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

        public void PreencherVetorUsuario()
        {
            string query = "select * from usuario";

            //instanciar os valores
            codigo = new int[100];
            nome = new string[100];
            telefone = new string[100];
            email = new string[100];
            dtnasc = new string[100];
            login = new string[100];
            senha = new string[100];

            //preencher com valores genericos
            for(i = 0; i < 100; i++)
            {
                codigo[i] = 0;
                nome[i] = "";
                telefone[i] = "";
                email[i] = "";
                dtnasc[i] = "";
                login[i] = "";
                senha[i] = "";
            }//fim do for

            //preparando o comando para o banco
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //leitura do banco
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            contador = 0;

            while(leitura.Read())
            {
                codigo[i] = Convert.ToInt32(leitura["codigo"]);
                nome[i] = "" + leitura["nome"];
                telefone[i] = "" + leitura["telefone"];
                email[i] = "" + leitura["email"];
                dtnasc[i] = "" + leitura["dtnasc"];
                login[i] = "" + leitura["login"];
                senha[i] = "" + leitura["senha"];
                i++;
                contador++;
            }//preenchendo o vetor com os dados do banco

            leitura.Close();//encerrar o acesso ao banco de dados
        }//fim do preencher

        public void InserirTarefa(string nomeTarefa, string descricaoTarefa, string dtTarefa)
        {
            try
            {
                dados = "(''
            }
        }
        


    }//fim da classe
}//fim do projeto
