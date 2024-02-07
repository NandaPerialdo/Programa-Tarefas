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
        public int[] dtTarefa;
        public int[] hora;
        public string msg;
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

        public void InserirTarefa(string nomeTarefa, string descricaoTarefa, int dtTarefa, int hora, int codigo)
        {
            try
            {
                dados = "('','" + nomeTarefa + "','" + descricaoTarefa + "','" + dtTarefa + "','" + hora + "','')";
                sql = "insert into tarefa(codigo, nome, descricao,dt,hora,codigo_usuario) values" + dados;

                MySqlCommand conn = new MySqlCommand(sql, conexao);//praparando a execuçao no banco
                resultado = "" + conn.ExecuteNonQuery();//executar a query no banco de dados (ctrl + enter)
                Console.WriteLine(resultado + " Linha afetada");
            }
            catch (Exception erro)
            {
                Console.WriteLine("Erro!!! Algo deu errado!\n\n\n" + erro);
            }//fim do try catch
        }//fim do metodo inserir tarefa
        
        //metodo que realiza a atualizaçao da tarefa dentro do banco
        public string AtualizarTarefa(int cod, string campo, string dado)
        {
            try
            {
                string query = "update tarefa set " + campo + " = '" + dado + "' where codigo = '" + cod + "'";
                //preparar o comando do banco de dados
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + " linha afetada!";
            }catch (Exception erro)
            {
                return "Algo deu errado!\n\n" + erro;
            }//fim do try catch
        }//fim do metodo atualizar tarefa

        public string Excluir(int cod)
        {
            string query = "delete from tarefa where codigo = '" + cod + "'";
            //preparar o comando
            MySqlCommand sql = new MySqlCommand(query, conexao);
            string resultado = "" + sql.ExecuteNonQuery();
            //mostrar o resultado p usuario
            return resultado + " Linha afetada";
        }//fim do metodo excluir

        //criando vetor para coletar os dados do banco de dados e posteriormente criar o
        //metodo consultar

        public void PreencherVetorTarefa()
        {
            string query = "select * from tarefa";

            //declarar vetores
            codigo = new int[100];
            nomeTarefa = new string[100];
            descricaoTarefa = new string[100];
            dtTarefa = new int[100]; 

            //preencher os vetores com valores genericos
            for(i = 0; i < 100;i++)
            {
                codigo[i] = 0;
                nomeTarefa[i] = "";
                descricaoTarefa[i] = "";
                dtTarefa[i] = 0;
            }//fim do for

            //preparando o comando para o banco
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //leitura do banco
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            contador = 0;

            //preencher o vetor com os dados do banco

            while(leitura.Read())
            {
                codigo[i] = Convert.ToInt32(leitura["codigo"]);
                nomeTarefa[i] = "" + leitura["nome"];
                descricaoTarefa[i] = "" + leitura["descricao"];
                dtTarefa[i] = Convert.ToInt32(leitura["dt"]);
                hora[i] = Convert.ToInt32(leitura["hora"]);
                i++;
                contador++;
            }//fim do while

            leitura.Close();//encerrar o acesso ao banco de dados
        }//fim do metodo preencher vetor tarefa

        //metodo para consultar todos os dados do banco de dados

        public string ConsultarTudoTarefa()
        {
            //preencher os vetores
            PreencherVetorTarefa();
            msg = "";
            for(i=0; i < contador; i++)
            {
                msg += "\n\nCódigo: " + codigo[i] +
                       " , Nome da Tarefa: " + nomeTarefa[i] +
                       " , Descrição: " + descricaoTarefa[i] +
                       " , Data: " + dtTarefa[i] +
                       " , Hora: " + hora[i];
            }//fim do for

            return msg;//mostrar em tela o que foi preenchido dentro dos vetores
        }//fim do metodo consultar tudo
        

    }//fim da classe
}//fim do projeto
