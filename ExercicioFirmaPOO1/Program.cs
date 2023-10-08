//Pratica em dupla até 09/10

//Desenvolva um sistema para uma Firma.
//Este sistema armazena as informações do empregado que inclui:
//Primeiro nome,
//sobrenome,
//matricula,
//idade,
//data de nascimento,
//data de contratação,
//salário mensal.


//O empregado pode ser criado no sistema com todas as informações
//completas ou somente com os dados básicos pessoais (nomes, idade, nascimento).

//Se o salário mensal for menor que um salário minimo, configure-o com o valor de um salario minimo. ok
//Quando os empregados recebem um aumento, sempre é de 10% no salário mensal.

//Crie um menu com as opções
//Cadastrar Empregado
//Listar Todos Empregados cadastrados
//Promover um Empregado, peça nome e sobrenome
//Demitir um Empregado, peça nome e sobrenome
//Listar salário anual do Empregado

//Pontos avaliativos: Classe, objeto, abstração, encapsulamento, propriedades, métodos, construtores.
//UML

using System;
namespace Exercicio4
{
    public class program
    {
        static List<Funcionario> listaFuncionarios = new();

        static void Main(string[] args)
        {
            bool flagLoop = true;
            while (flagLoop)
            {
                Console.WriteLine("Menu de controle, selecione o que deseja fazer.");
                Console.WriteLine("1- Cadastrar Empregado");
                Console.WriteLine("2- Listar Todos Empregados cadastrados");
                Console.WriteLine("3- Promover um Empregado");
                Console.WriteLine("4- Demitir um Empregado");
                Console.WriteLine("5- Listar salário anual do Empregado");
                Console.WriteLine("6- Sair do programa");

                int selecaoMenu = Int32.Parse(Console.ReadLine());

                switch (selecaoMenu)
                {
                    case 1:
                        CadastrarFuncionario();
                        break;

                    case 2:
                        ListarFuncionarios();
                        break;

                    case 6:
                        flagLoop = false;
                        break;
                    case 5:
                        ListarSalario();
                        break;
                }
                //fazer Swicth
            }


        }

        internal static void CadastrarFuncionario()
        {
            Console.WriteLine(" Você selecionou cadastrar empregado, digite os seguintes dados");

            Console.WriteLine("Digite o primeiro nome");
            string primeiroNome = Console.ReadLine();

            Console.WriteLine("Digite o segundo nome");
            string segundoNome = Console.ReadLine();

            Console.WriteLine("Digite a idade ");
            int idadeAtual = Int32.Parse((Console.ReadLine()));

            Console.WriteLine("Digite a data de nascimento");
            DateTime dataNascimento = DateTime.Parse(Console.ReadLine()); //mudar para DateTime

            Console.WriteLine("Digite a data de contratação");
            DateTime dataContratacao = DateTime.Parse((Console.ReadLine()));

            Console.WriteLine("Digite o salario");
            double salario = double.Parse(Console.ReadLine());


            Random random = new Random();
            int matricula = random.Next();

            Funcionario funcionarioNovo = new(primeiroNome, segundoNome, idadeAtual, dataNascimento, matricula, salario, dataContratacao);

            listaFuncionarios.Add(funcionarioNovo);
        }
        internal static void ListarFuncionarios()
        {
            foreach (var funcionario in listaFuncionarios)
            {
                Console.WriteLine("Nome: " + funcionario.nome);
                Console.WriteLine("Sobrenome: " + funcionario.sobrenome);
                Console.WriteLine("Idade: " + funcionario.idade + " anos");
                Console.WriteLine("Data de Nascimento: " + funcionario.dataNascimento);
                Console.WriteLine("Data de Contratação: " + funcionario.dataContratação);
                Console.WriteLine("Salario: " + funcionario.salario);
                Console.WriteLine("Matricula: " + funcionario.matricula);
                Console.WriteLine("");

            }
        }
        internal static void PromoverFuncionario()
        {
            Console.WriteLine("Por favor, insira o nome e sobre nome do funcionario a ser promovido.");

            string nomeCompleto = Console.ReadLine();


            string[] nome = nomeCompleto.Split(" ");
            string primeiroNome = nome[0];
            string segundoNome = nome[1];

            Funcionario funcionarioPromovido = listaFuncionarios.Find(funcionario => funcionario.nome.Equals(primeiroNome) && funcionario.sobrenome.Equals(segundoNome));

            funcionarioPromovido.salario = funcionarioPromovido.salario * 1.10;
        }

        internal static void DemitirFuncionario()
        {

            Console.WriteLine("Por favor, insira o nome e sobre nome do funcionario a ser demitido.");

            string nomeCompleto = Console.ReadLine();


            string[] nome = nomeCompleto.Split(" ");
            string primeiroNome = nome[0];
            string segundoNome = nome[1];

            Funcionario funcionarioDemitido = listaFuncionarios.Find(funcionario => funcionario.nome.Equals(primeiroNome) && funcionario.sobrenome.Equals(segundoNome));
            listaFuncionarios.Remove(funcionarioDemitido);


            Console.WriteLine($"O funcionario {nomeCompleto} foi demitido");
        }

        internal static void ListarSalario()
        {
            foreach (var funcionario in listaFuncionarios)
            {

                double salarioAnual = funcionario.salario * 12;

                Console.WriteLine($"O salario anul do {funcionario.nome + funcionario.sobrenome} é de {salarioAnual}");



            }
        }
    }
}