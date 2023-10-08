using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio4
{
    public class Funcionario
    {
        public string nome { get; private set; }
        public string sobrenome { get; private set; }
        private int matricula { get; set; }
        private int idade { get; set; }
        public DateTime dataNascimento { get; set; }
        private DateTime dataContratacao { get; set; }
        private double salario { get; set; }



        public Funcionario(string nome, string sobrenome, int idade, DateTime dataNascimento, int matricula, double salario = 0, DateTime dataContratacao = new DateTime())
        {
            this.nome = nome;
            this.sobrenome = sobrenome;
            this.matricula = matricula;
            this.idade = idade;
            this.dataNascimento = dataNascimento;
            this.dataContratacao = dataContratacao;
            this.salario = salario;



            if (salario < 1320)
            {
                salario = 1320;
            }
            this.salario = salario;
        }


        internal void Promover()
        {
            this.salario = this.salario * 1.1;
        }

        internal double calcularSalarioAnual()
        {
            return this.salario * 12;
        }

        internal void listarInformacoes()
        {
            {
                Console.WriteLine("Nome: " + this.nome);
                Console.WriteLine("Sobrenome: " + this.sobrenome);
                Console.WriteLine("Idade: " + this.idade + " anos");
                Console.WriteLine("Data de Nascimento: " + this.dataNascimento.Date);
                Console.WriteLine("Data de Contratação: " + this.dataContratacao.Date);
                Console.WriteLine("Salario: R$ " + this.salario);
                Console.WriteLine("Matricula: n°" + this.matricula);
                Console.WriteLine("");
            }
        }

    }
}

