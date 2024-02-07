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
        private int ConsultarOpcaoTarefas;
        private int opcaoAlterar;
        public int codTarefa;
        public int codigo;
        

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

        public void MenuPrincipal()
        {
            Console.WriteLine("\nO que deseja fazer?: \n\n" +
                              "1. Menu \n" +
                              "2. Fazer Cadastro \n" +
                              "3. Sair");
            ConsultarOpcao = Convert.ToInt32(Console.ReadLine());
        }//fim do metodo menu

        public void MostrarMenuTarefas()
        {
            Console.WriteLine("\nEscolha uma opção:\n\n" +
                              "1. Criar Tarefa.\n" +
                              "2. Alterar Tarefa.\n" +
                              "3. Excluir Tarefa.\n" +
                              "4. Consultar Tarefa.\n");
            ConsultarOpcaoTarefas = Convert.ToInt32(Console.ReadLine());
        }//fim do menu tarefa

        public void Operacao()
        {
            do
            {
                MenuPrincipal();//mostrar menu pro usuario
                switch (ConsultarOpcao)
                {
                    case 1:
                        //fazer login
                        MenuTarefas();
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
            Console.WriteLine("Insira sua senha: ");
            string senha = Console.ReadLine();
            //inserir no banco de dados
            conectar.InserirUsuario(nome, telefone, email, datanasc, login, senha);
        }//fim do metodo cadastrar usuario

        public void MenuTarefas()
        {
            MostrarMenuTarefas();
            switch (ConsultarOpcaoTarefas)
            {
                case 1:
                    //criar tarefa
                    Console.WriteLine("Qual o nome da tarefa?");
                    string nomeTarefa = Console.ReadLine();
                    Console.WriteLine("Qual a descrição?");
                    string descricaoTarefa = Console.ReadLine();
                    Console.WriteLine("Qual a data?");
                    int dtTarefa = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Qual a hora?");
                    int hora = Convert.ToInt32(Console.ReadLine());
                    //inserir no banco
                    conectar.InserirTarefa(nomeTarefa, descricaoTarefa, dtTarefa, hora,codigo);//conectando este metodo ao metodo "inserirTarefa" da DAO
                    break;
                case 2:
                    //alterar tarefa
                    AlterarTarefa();
                    break;
                case 3:
                    //excluir tarefa
                    ExcluirTarefa();
                    break;
                case 4:
                    //consultar tarefa
                    ConsultarTudoTarefa();
                    break;
                default:
                    Console.WriteLine("Erro! Opção inválida");
                    break;
            }//fim do switch           
        }//fim do metodo mostrar menu tarefas

        public void MostrarMenuAlterar()
        {
            Console.WriteLine("\n\nQual campo deseja alterar?\n\n" +
                              "\n1.Nome da tarefa. " +
                              "\n2.Descrição da tarefa. " +
                              "\n3.Data da tarefa. ");
            opcaoAlterar = Convert.ToInt32(Console.ReadLine());
        }//fim do metodo que mostra o menu alterar

        //metodo que altera os campos de uma tarefa
        public void AlterarTarefa()
        {
            MostrarMenuAlterar();
            switch (opcaoAlterar)
            {
                case 1:
                    //alterar nome da tarefa
                    Console.WriteLine("Informe o código da tarefa que deseja atualizar: ");
                    codTarefa = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe o novo nome:");
                    string nomeTarefa = Console.ReadLine();
                    Console.WriteLine("\n\n" + conectar.AtualizarTarefa(codTarefa, "nome", nomeTarefa));
                    break;
                case 2:
                    //alterar descricao da tarefa
                    Console.WriteLine("Informe o código da tarefa que deseja atualizar: ");
                    codTarefa = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe a nova descricao:");
                    string descricaoTarefa = Console.ReadLine();
                    Console.WriteLine("\n\n" + conectar.AtualizarTarefa(codTarefa, "nome", descricaoTarefa));
                    break;
                case 3:
                    //alterar data da tarefa
                    Console.WriteLine("Informe o código da tarefa que deseja atualizar: ");
                    codTarefa = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe a nova data:");
                    int dtTarefa = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\n\n" + conectar.AtualizarTarefa(codTarefa, "nome", Convert.ToString(dtTarefa)));
                    break;
                default:
                    Console.WriteLine("Insira uma opção válida");
                    break;
            }//fim do switch
        }//fim do metodo alterar tarefa

        public void ExcluirTarefa()
        {
            Console.WriteLine("Informe o código da tarefa que deseja excluir:");
            codTarefa = Convert.ToInt32(Console.ReadLine());
            //utilizar o metodo excluir
            Console.WriteLine("\n\n" + conectar.Excluir(codTarefa));
        }//fim do metodo excluir tarefa

        //colocar o metodo consultar tudo dentro de um console.writeline para que a mensagem
        //seja exibida ao rodar o metodo

        public void ConsultarTudoTarefa()
        {
            Console.WriteLine(conectar.ConsultarTudoTarefa());
        }//fim do metodo consultar tudo


        
    }// fim da classe
}//fim do projeto
