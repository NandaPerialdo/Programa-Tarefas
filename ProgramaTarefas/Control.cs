using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaTarefas
{
    class ControlUsuario
    {
        DAO conectar;// criando uma variavel (conectar) para representar
                     // o DAO
        private int opcao;
        public int ConsultarOpcaoTarefas;

        public ControlUsuario() //criando o metodo contrutor
        {
            ConsultarOpcao = 0;
            conectar = new DAO();//conectando a variavel conectar
                                 //ao DAO (banco de dados)
        }//fim do construtor

        public int ConsultarOpcao
        {
            get { return this.opcao; }
            set { this.opcao = value; }
        }//fim do metodo get set

        public void Menu()
        {
            Console.WriteLine("O que deseja fazer?: \n" +
                              "1. Fazer Login \n" +
                              "2. Fazer Cadastro \n" +
                              "3. Sair");
            ConsultarOpcao = Convert.ToInt32(Console.ReadLine());
        }//fim do metodo menu

        public void Operacao()
        {
            do
            {
                Menu();//mostrar menu pro usuario
                switch (ConsultarOpcao)
                {
                    case 1:
                        //fazer login
                        do
                        {
                            MenuTarefas();
                            switch (ConsultarOpcaoTarefas)
                            {
                                case 1:
                                    //criar tarefa
                                    break;
                                case 2:
                                    //alterar tarefa
                                    break;
                                case 3:
                                    //excluir tarefa 
                                    break;
                                case 4:
                                    //consultar tarefa
                                    break;
                                default:
                                    //caso o usuario insira um numero diferente de 4
                                    Console.WriteLine("Erro! Escolha uma opção entre 1 e 4");
                                    break;
                            }//fim do escolha caso
                        } while (ConsultarOpcaoTarefas != 4);
                        break;
                    case 2:
                        //fazer cadastro
                        CadastrarUsuario();
                        break;
                    case 3:
                        //sair
                        Console.WriteLine("Obrigado!");
                        break;
                    default: //caso o usuário insira uma "case" que não exista
                        Console.WriteLine("Erro! Informe uma opção válida");
                        break;
                }//fim do escolha caso
            } while (ConsultarOpcao != 3);
        }//fim do metodo operacao

        public void CadastrarUsuario()
        {
            //guardando as informações em variaveis para preencher o banco de dados
            Console.WriteLine("Insira seu nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Insira o telefone: ");
            string telefone = Console.ReadLine();
            Console.WriteLine("Insira o email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Insira a data de nascimento: ");
            string datanasc = Console.ReadLine();
            Console.WriteLine("Insira seu nome de login: ");
            string login = Console.ReadLine();
            Console.WriteLine("Insira seu nome de senha: ");
            string senha = Console.ReadLine();
            //inserir no banco de dados
            conectar.InserirUsuario(nome, telefone, email, datanasc, login, senha);
        }//fim do metodo cadastrar usuario

        public void MenuTarefas()
        {
            Console.WriteLine("Escolha uma opção:\n" +
                              "1. Criar Tarefa.\n" +
                              "2. Alterar Tarefa.\n" +
                              "3. Excluir Tarefa.\n" +
                              "4. Consultar Tarefa.\n");
            int ConsultarOpcaoTarefas = Convert.ToInt32(Console.ReadLine());
    }//fim do menu tarefa

        public void CriarTarefa()
        {
            Console.WriteLine("Qual o nome da tarefa?");
            nomeTarefa = Console.ReadLine();
            Console.WriteLine("Qual a descrição?");
            descricaoTarefa = Console.ReadLine();
            Console.WriteLine("Qual a data de execução?");
            dtTarefa = Console.WriteLine();
            //inserir no banco de dados
            conectar.InserirTarefa(nomeTarefa, descricaoTarefa, dtTarefa);
        }//fim do metodo criar tarefa







    }// fim da classe

}//fim do projeto
