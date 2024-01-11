using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Horario
    {
        //atributos da classe
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }

        //Construtor
        public Horario(string id, string nome, string tipo)
        {
            Id = id;
            Nome = nome;
            Tipo = tipo;
        }

        // Método para exibir informações do funcionário
        public string ExibirInformacoes()
        {
            return $"ID: {Id}\nNome: {Nome}\nTipo: {Tipo}\n";
        }
    }
}
