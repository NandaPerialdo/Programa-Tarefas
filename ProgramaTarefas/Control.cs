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
                        break;
                    case 2:
                        //fazer cadastro
                        CadastrarUsuario();
                        break;
                    case 3:
                        //sair
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
            conectar.InserirUsuario(nome,telefone,email,datanasc, login, senha);
        }//fim do metodo cadastrar usuario



    }// fim da classe
}//fim do projeto
