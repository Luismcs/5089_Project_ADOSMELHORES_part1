using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class FileHandler
    {
        public static void WriteToFile(string frase, string nomeficheiro) //escreve sem alterar o que estava antes
        {
            StreamWriter escrita = new StreamWriter(nomeficheiro, true); //cria variavel de escrita para um ficheiro sem apagar o que estava antes
            escrita.WriteLine(frase); //escrever a frase na consola
            escrita.Close(); //fecha o construtor de escrita
        }

        public static void ReadFromFile(string nomeficheiro, string nomeficheiroescrita)
        {
            StreamReader leitura = new StreamReader(nomeficheiro); //cria variavel de leitura para um ficheiro
            while (!leitura.EndOfStream) //Lê linhas enquanto não chegar ao fim do ficheiro de leitura
            {
                string linha = leitura.ReadLine(); //Lê a linha do ficheiro de leitura
                WriteToFile(linha, nomeficheiroescrita); //escreve a linha no ficheiro de escrita
            }
            leitura.Close(); //fecha a variavel de leitura
        }

        public static void WriteToFileReset(string frase, string nomeficheiro) //escreve alterando o que estava antes
        {
            StreamWriter escrita = new StreamWriter(nomeficheiro); //cria variavel de escrita para um ficheiro sem apagar o que estava antes
            escrita.WriteLine(frase); //escrever a frase na consola
            escrita.Close(); //fecha o construtor de escrita
        }
    }
}
