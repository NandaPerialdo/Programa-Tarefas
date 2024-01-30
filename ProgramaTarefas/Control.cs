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
            conectar = new DAO();//conectando a variavel conectar
                                 //ao DAO (banco de dados)
        }//fim do construtor

        public int ConsultarOpcao
        {
            get { return this.ConsultarOpcao; }
            set { this.ConsultarOpcao = value; }
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

        public void Cadastrar()
        {
            Console.WriteLine("Insira o nome da pessoa: ");

        }



    }// fim da classe
}//fim do projeto
