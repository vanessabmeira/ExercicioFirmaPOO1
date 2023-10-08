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
using System.Collections.Generic;

namespace Exercicio4
{
    public class Empresa
    {


        /// <summary>
        /// Lista para armazenar funcionários
        /// </summary>
        private static List<Funcionario> listaFuncionarios = new();


        //Menu de opções da empresa, para cadastro, Listar os empregados, promover e listar o salario anual do Empregado

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
                Console.WriteLine(" ");
                try
                {
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
                            ListarSalarioAnual();
                            break;
                        case 3:
                            PromoverFuncionario();
                            break;
                        case 4:
                            DemitirFuncionario();
                            break;
                    }

                }
                catch (FormatException f) {
                    Console.WriteLine("Por favor insira um valor válido");
                    Console.ReadLine();
                    continue;
                    
                 }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }

                Console.Clear();
            }


        }

        /// <summary>
        /// Lista para armazenar funcionários
        /// </summary>
        internal static void CadastrarFuncionario()

        {
            try
            {
                Console.WriteLine(" Você selecionou cadastrar empregado, digite os seguintes dados");
                Console.WriteLine("\nDigite o primeiro nome");
                string primeiroNome = Console.ReadLine();
                Console.WriteLine("\nDigite o sobrenome");
                string sobrenome = Console.ReadLine();
                Console.WriteLine("\nDigite a idade ");
                int idadeAtual = Int32.Parse((Console.ReadLine()));
                Console.WriteLine("\nDigite a data de nascimento");
                DateTime dataNascimento = DateTime.Parse(Console.ReadLine()); 
                Console.WriteLine("\nDigite a data de contratação");
                DateTime dataContratacao = DateTime.Parse((Console.ReadLine()));
                Console.WriteLine("\nDigite o salario");
                double salario = double.Parse(Console.ReadLine());




                Random random = new Random();
                int matricula = random.Next();

                Funcionario funcionarioNovo = new(primeiroNome, sobrenome, idadeAtual, dataNascimento, matricula, salario, dataContratacao);

                listaFuncionarios.Add(funcionarioNovo);

                Console.WriteLine("\nFuncionário cadastrado com sucesso");
                Console.WriteLine("\nAperte ENTER para retornar ao menu");
                Console.ReadLine();
            }
            catch (FormatException f)
            {
                Console.WriteLine("Cadastro de funcionário cancelado - Por favor insira um valor válido");
                Console.ReadLine();
            }
        }
        /// <summary>
        /// Método para listar todos os funcionários cadastrados
        /// </summary>
        private static void ListarFuncionarios()
        {
            if (!listaFuncionarios.Any())//Trata caso não existir nem um funcionario cadastrado.
            {
                Console.WriteLine("Não há nenhum funcionário cadastrado");
                Console.WriteLine("\nAperte ENTER para retornar ao menu");
                Console.ReadLine();
            }
            else
            {
                foreach (var funcionario in listaFuncionarios)
                {
                    funcionario.listarInformacoes();
                    Console.WriteLine("\nAperte ENTER para retornar ao menu");
                    Console.ReadLine();
                }
            }
            
        }
        /// <summary>
        /// Método usado para promover um funcionário.
        /// </summary>

        private static void PromoverFuncionario()
        {
            Console.WriteLine("Por favor, insira o nome e sobre nome do funcionario a ser promovido.");

            string nomeCompleto = Console.ReadLine();
            string[] nomeDividido = nomeCompleto.Split(" "); // Procura o "caractere" espaço para quebrar o nome que foi digitado completo pelo usuario.

            Funcionario funcionarioPromovido = listaFuncionarios.Find(funcionario => funcionario.nome.Equals(nomeDividido[0]) && funcionario.sobrenome.Equals(nomeDividido[1]));
            if (funcionarioPromovido != null)
            {
                funcionarioPromovido.Promover();
                Console.WriteLine($"O funcionário {nomeCompleto} foi promovido !");
            }
            else
            {
                Console.WriteLine("Funcionário inexistente no cadastro da empresa");
            }

            Console.WriteLine("\nAperte ENTER para retornar ao menu");
            Console.ReadLine();
        }
        /// <summary>
        /// Método para demitir um funcionário
        /// </summary>

        private static void DemitirFuncionario()
        {

            Console.WriteLine("Por favor, insira o nome e sobre nome do funcionario a ser demitido.");

            string nomeCompleto = Console.ReadLine();
            string[] nomeDividido = nomeCompleto.Split(" ");

            Funcionario funcionarioDemitido = listaFuncionarios.Find(funcionario => funcionario.nome.Equals(nomeDividido[0]) && funcionario.sobrenome.Equals(nomeDividido[1]));

            if (funcionarioDemitido != null)
            {
                listaFuncionarios.Remove(funcionarioDemitido);
                Console.WriteLine($"O funcionario {nomeCompleto} foi demitido");
            }
            else
            {
                Console.WriteLine("Funcionário inexistente no cadastro da empresa");
            }

            Console.WriteLine("\nAperte ENTER para retornar ao menu");
            Console.ReadLine();

        }

        /// <summary>
        /// Método para listar o salário anual de todos os funcionários
        /// </summary>

        private static void ListarSalarioAnual()
        {
            foreach (var funcionario in listaFuncionarios)
            {
                Console.WriteLine($"Funcionário: {funcionario.nome + funcionario.sobrenome} - Salário anual: R${funcionario.calcularSalarioAnual()}");
            }

            Console.WriteLine("\nAperte ENTER para retornar ao menu");
            Console.ReadLine();
        }
    }
}
