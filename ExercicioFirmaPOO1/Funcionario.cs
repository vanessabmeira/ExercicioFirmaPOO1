using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio4
{
    public class Funcionario
    {
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public int matricula { get; set; }
        public int idade { get; set; }
        public DateTime dataNascimento { get; set; }
        public DateTime dataContratação { get; set; }
        public double salario { get; set; }



        public Funcionario(string nome, string sobrenome, int idade, DateTime dataNascimento, int matricula, double salario = 0, DateTime dataContratação = new DateTime())
        {
            this.nome = nome;
            this.sobrenome = sobrenome;
            this.matricula = matricula;
            this.idade = idade;
            this.dataNascimento = dataNascimento;
            this.dataContratação = dataContratação;
            this.salario = salario;



            if (salario < 1320)
            {
                salario = 1320;
            }
            this.salario = salario;
        }


    }
}
