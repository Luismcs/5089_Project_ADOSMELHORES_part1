using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Empresa
    {
        List<Funcionario> funcionarios = new List<Funcionario>(); //lista de funcionários
        List<Horario> horarios = new List<Horario>(); //lista de horários
        List<Funcionario> naoalocados = new List<Funcionario>(); //lista de funcionários não alocados


        // Constructor
        public Empresa()
        {


        }


        public void LerFicheiro() //lê ficheiro de funcionarios e o ficheiro de horarios
        {
            string id;
            string nome;
            string morada;
            string telefone;
            string dataFim;
            string dataRegisto;
            string isencao;
            string bonus;
            string carro;
            string chefe;
            string area;
            string disponibilidade;
            string valorHora;


            // Verificar se o arquivo existe antes de tentar lê-lo
            if (File.Exists("funcionarios.txt"))
            {
                // Usar StreamReader para ler o arquivo linha por linha
                StreamReader sr = new StreamReader(@"funcionarios.txt");


                while (!sr.EndOfStream)
                {
                    string[] vec_fun = sr.ReadLine().Split(';'); //le a linha para um vetor
                    id = vec_fun[0];
                    nome = vec_fun[1];
                    morada = vec_fun[2];
                    telefone = vec_fun[3];
                    dataFim = vec_fun[4];
                    dataRegisto = vec_fun[5];
                    area = vec_fun[6];
                    disponibilidade = vec_fun[7];
                    valorHora = vec_fun[8];
                    isencao = vec_fun[9];
                    bonus = vec_fun[10];
                    carro = vec_fun[11];
                    chefe = vec_fun[12];
                    Funcionario funcionario = new Funcionario(id, nome, morada, telefone, dataFim, dataRegisto, isencao, bonus, carro, chefe, area, disponibilidade, valorHora); //cria um objeto funcionario
                    funcionarios.Add(funcionario); //adiciona funcionario á lista
                }
                sr.Close();
            }
            else
            {
                Console.WriteLine("O ficheiro 'funcionarios.txt' não foi encontrado.");
            }

            if (File.Exists("Horarios.txt"))
            {
                // Usar StreamReader para ler o arquivo linha por linha
                using (StreamReader sh = new StreamReader("Horarios.txt"))
                {
                    string linha;
                    string tipo;
                    while (!sh.EndOfStream)
                    {
                        string[] vec_hor = sh.ReadLine().Split(';'); //le a linha para um vetor
                        id = vec_hor[0];
                        nome = vec_hor[1];
                        tipo = vec_hor[2];
                        Horario horario = new Horario(id, nome, tipo); //cria um objeto funcionario
                        horarios.Add(horario); //adiciona funcionario á lista
                    }
                }
            }
            else
            {
                Console.WriteLine("O ficheiro 'horarios.txt' não foi encontrado.");
            }
        }

        public void adicionaFun()
        {
            StreamWriter sw = new StreamWriter(@"Funcionarios.txt",true);
            string id, nome, morada, contacto, dataFim, dataRegisto, chefe, area, disponibilidade = "", valorhora, isencao, bonus, carro;
            Console.WriteLine("Introduza o nome: ");
            nome =Console.ReadLine();

            if (!validaSemNumeros(nome))
            {
                return;
            }
            Console.WriteLine("Introduza a morada: ");
            morada = Console.ReadLine();
            Console.WriteLine("Introduza o contacto: ");
            contacto = Console.ReadLine();

            if (!verificaTelefone(contacto)) //valida contacto inserido
            {
                return;
            }

            Console.WriteLine("Introduza a data de fim de contrato: ");
            dataFim = Console.ReadLine();

            if(!verificaData(dataFim))
            {
                Console.WriteLine("Adição cancelada\n");
                return;
            }

            Console.WriteLine("Introduza a data de fim de registo: ");
            dataRegisto = Console.ReadLine();

            if (!verificaData(dataRegisto))
            {
                return;
            }

            Console.WriteLine("Introduza o chefe: ");
            chefe = Console.ReadLine();
            if (!validaSemNumeros(chefe))
            {
                return;
            }
            Console.WriteLine("Introduza a área: ");
            area = Console.ReadLine();
            if (!validaSemNumeros(area))
            {
                return;
            }
            Console.WriteLine("Introduza a valor por hora: ");
            valorhora = Console.ReadLine();

            if (!verificaValor(valorhora))
            {
                return;
            }

            Console.WriteLine("Isenção? (S / N)");
            isencao = Console.ReadLine();
            
            if(!validaResposta(isencao)) //valida resposta isencao
            {
                Console.WriteLine("Insira uma opção válida");
                return;
            }

            Console.WriteLine("Bónus? (S / N)");
            bonus = Console.ReadLine();

            if (!validaResposta(bonus)) //valida resposta bonus
            {
                Console.WriteLine("Insira uma opção válida");
                return;
            }

            Console.WriteLine("Carro? (S / N)");
            carro = Console.ReadLine();
            
            if (!validaResposta(carro)) //valida resposta carro
            {
                Console.WriteLine("Insira uma opção válida");
                return;
            }


            int count = 0;

            foreach (Funcionario funcionario in funcionarios) //conta o numero de funcionario
            {
                count++;
            }

            count = count + 1;
            id = count.ToString();

            //Criar novo Funcionário 

            Funcionario novoFuncionario = new Funcionario(id, nome, morada, contacto, dataFim, dataRegisto, chefe, area, disponibilidade, valorhora,isencao, bonus, carro);
            funcionarios.Add(novoFuncionario);
            Console.WriteLine("Funcionário adicionado com sucesso.");

            string frase = id + ";" + nome + ";" + morada + ";" + contacto + ";" + dataFim + ";" + dataRegisto + ";" + isencao + ";" + bonus + ";" + carro + ";" + chefe + ";" + area+ ";" + disponibilidade + ";"+valorhora;
            sw.WriteLine(frase);
            sw.Close();
        }

        public bool verificaTelefone(string telefone) //valida telefone
        {
            foreach (char c in telefone) //percorre o contacto
            {
                if (char.IsLetter(c)) //se encontrar uma letra retorna falso
                {
                    Console.Clear();
                    Console.WriteLine("Adição cancelada\n");
                    Console.WriteLine("Não pode introduzir letras.");
                    return false;
                }

                if (telefone.Length != 9) //se o tamanho for maior ou menor que 9 retorna falso
                {
                    Console.Clear();
                    Console.WriteLine("Adição cancelada\n");
                    Console.WriteLine("O telefone tem de ter 9 digitos.");
                    return false;
                }
            }
            return true;
        }

        public bool verificaValor(string valor) //valida valor ganho por hora
        {
            foreach (char c in valor) //percorre o contacto
            {
                if (char.IsLetter(c)) //se encontrar uma letra retorna falso
                {
                    Console.Clear();
                    Console.WriteLine("Adição cancelada\n");
                    Console.WriteLine("Não pode introduzir letras.");
                    return false;
                }
            }
            return true;
        }

        public bool validaResposta(string resposta) //valida resposta inserida
        {
            resposta=resposta.Trim(); //retira espaços se houver
            resposta=resposta.ToLower(); //coloca tudo em letras minusculas 

            if (resposta == "s")
            {
                return true;
            }
            else if (resposta == "n")
            {
                return true;
            }
            else
            {
                Console.WriteLine("Adição cancelada\n");
                return false;
            }
        }

        public bool verificaData(string data) //valida data
        {
            int contador = 0;

            foreach (char c in data) //percorre a data
            {
                if (!char.IsDigit(c) && c != '/') //valida se foram apenas inseridos numeros ou /
                {
                    Console.Clear();
                    Console.WriteLine("Adição cancelada");
                    Console.WriteLine("Não pode introduzir letras ou caracteres especiais, exceto '/'\n");
                    return false;
                }
            }

            foreach (char c in data) //percorre a data 
            {
                if (c.ToString() == "/") //conta numero de barras
                {
                    contador++;
                }
            }
            if (contador != 2) //verifica se tem apenas 2 barras
            {
                Console.Clear();
                Console.WriteLine("Adição cancelada");
                Console.WriteLine("O formato introduzido não é valido\n");
                return false;
            }

            if (data.Length != 10 || data[2] != '/' || data[5] != '/') //verifica o formato da data inserida
            {
                Console.Clear();
                Console.WriteLine("Adição cancelada");
                Console.WriteLine("O formato da data deve ser DD/MM/YYYY (dia, mês, ano).\n");
                return false;
            }

            if (Convert.ToInt32(data.Substring(0, 2)) > 31 || Convert.ToInt32(data.Substring(0, 2)) < 1) //verifica numero do dia
            {
                Console.Clear();
                Console.WriteLine("Adição cancelada");
                Console.WriteLine("O dia tem de ser entre 1 e 31.\n");
                return false;
            }
            if (Convert.ToInt32(data.Substring(3, 2)) > 12 || Convert.ToInt32(data.Substring(3, 2)) < 1) //verifica numero do mes
            {
                Console.Clear();
                Console.WriteLine("Adição cancelada");
                Console.WriteLine("O mês tem de ser entre 1 e 12.\n");
                return false;
            }

            return true; //se for valida retorna true
        }

        //Exercicio2

        public void alocar() //seleciona o horario e escreve no ficheiro Horarios.txt o id o nome e o tipo de horário selecionado
        {
            Console.WriteLine("Introduza o id do funcionário: ");
            string id = Console.ReadLine();
            string tipo = "";

            if (!validaId(id))
            {
                return;
            }

            foreach (Horario horario in horarios) //verifica se já foi alocado um horário ao funcionário
            {
                if (horario.Id == id)
                {
                    Console.Clear();
                    Console.WriteLine("Já foi alocado um horario a este funcionário\n");
                    return;
                }
            }

            foreach (Funcionario fun in funcionarios)
            {
                if (fun._Id == id)
                {
                    Console.WriteLine("Tem a certeza que é este funcionário? ");
                    Console.WriteLine(fun.ExibirInformacoes()); //exibe informações do funcionário introduzido
                    Console.WriteLine("S/N: ");
                    string resposta = Console.ReadLine(); //Lê a resposta
                    resposta = resposta.ToLower(); //permite maiusculas e minusculas

                    if (resposta == "n") //se resposta é n cancela a alocação de horário
                    {
                        Console.WriteLine("Alocação de horário cancelada");
                        return;
                    }

                    else if (resposta == "s")
                    {
                        Console.WriteLine("1-Pós-Laboral: ");
                        Console.WriteLine("2-Laboral: ");
                        Console.WriteLine("3-Ambas: ");
                        Console.WriteLine("Introduza o tipo de horário: ");
                        tipo = Console.ReadLine();
                        string[] vec_fun = { id + fun._Nome + tipo };          //coloca os atributos num vetor
                        Horario horario = new Horario(id, fun._Nome, tipo);   //cria um objeto horário
                        Console.Clear();

                        // Altera a designação na lista de funcionários
                        if (tipo == "1")
                        {
                            fun._Disponibilidade = "Pós-Laboral";
                        }
                        else if (tipo == "2")
                        {
                            fun._Disponibilidade = "Laboral";
                        }
                        else if (tipo == "3")
                        {
                            fun._Disponibilidade = "Ambas";
                        }
                        else //verifica se a opção é válida
                        {
                            Console.WriteLine("Introduza uma opção válida");
                            return;
                        }

                        horarios.Add(horario);                                //adiciona horario à lista
                        string frase = fun._Id + ";" + fun._Nome + ";" + tipo;  //cria a frase a colocar no horario.txt
                        FileHandler.WriteToFile(frase, @"Horarios.txt");      //escreve a frase no horario.txt
                        copiaFuncionarios(funcionarios, @"Funcionarios.txt"); //copia lista atualizada para o ficheiro Funcionarios.txt
                        Console.WriteLine("Funcionario alocado");
                        return;
                    }
                    else //resposta inválida
                    {
                        Console.Clear();
                        Console.WriteLine("Introduza uma resposta válida");
                        return;
                    }

                }

            }
            Console.WriteLine("Funcionario nao encontrado");

        }

        public bool verHorario(string op) //verifica se o funcionário já existe na lista de horarios
        {
            foreach (Horario line in horarios)
            {
                if (op == line.Id)
                {
                    return true; //se já existir retorna true
                }
            }
            return false;
        }

        public void imprimeFuncionarios() //imprime a lista de funcionarios
        {
            Console.Clear(); //limpa a consola

            Console.WriteLine("Lista de funcionários:\n");
            foreach (Funcionario funcionario in funcionarios)
            {
                Console.WriteLine(funcionario.ExibirInformacoes()+"\n"); //exibe informações de todos os funcionários
            }
        }

        public void imprimeHorarios() //imprime a lista de horários
        {
            // Mostrar o conteúdo na console linha por linha
            bool ver = false;

            Console.Clear();//limpa a consola

            Console.WriteLine("Lista de Horarios:\n");

            foreach (Horario line in horarios)
            {
                Console.WriteLine(line.ExibirInformacoes()); //exibe informação de todos os horários
                ver = true;
            }

            if (ver == false)
            {
                Console.WriteLine("Lista de horários vazia\n");
            }
        }

        //Exercicio 3

        public void GastosEmpresa()
        {
            double gastos = 0.0;
            if (funcionarios != null && funcionarios.Count > 0)
            {
                foreach (Funcionario funcionario in funcionarios) //percorre lista de funcionários
                {
                    gastos += funcionario.CalcularSalario(); //calcula o total de cada funcionário

                }
            }
            Console.WriteLine($"\nOs gastos da empresa são de {gastos} euros\n"); //imprime os gastos da empresa
        }

        //Exercicio 5

        public void naoAlocados() //mostra os funcionários por alocar a um horário
        {
            string idfun;
            bool ver = false;

            foreach (Funcionario funcionario in funcionarios) //compara cada funcionario aos funcionarios que estão na lista de horários
            {
                idfun = funcionario._Id; //recebe o id do funcionário
                ver = false;

                foreach (Horario alocado in horarios)
                {

                    if (alocado.Id == idfun)
                    {
                        ver = true; //se o fucnionario existe ver é true
                    }
                }

                if (!ver) //se o funcionário ainda não foi alocado a um horário 
                {
                    string id = funcionario._Id;
                    string nome = funcionario._Nome;
                    string frase = id + ";" + nome;
                    naoalocados.Add(funcionario);
                }
                copiaNaoAlocados(naoalocados);

            }


            bool vazio = false; //verifica se a lista está vazia

            Console.WriteLine("Lista de Funcionários não alocados: \n");

            foreach (Funcionario line in naoalocados) //imprime informações de funcionários não alocados da lista naoalocados
            {
                Console.WriteLine(line.ExibirInformacoes()+"\n");
                vazio = true;
            }

            if (!vazio) //se a lista está vazia imprime a mensagem
            {
                Console.WriteLine("Lista de não alocaldos vazia\n");
            }
        }

        public static void copiaFuncionarios(List<Funcionario> listafuncionarios, string nomeFicheiro) //copia a lista de funcionários para o ficheiro funcionarios.txt
        {
            try
            {
                StreamWriter sw = new StreamWriter(@"Funcionarios.txt");

                foreach (Funcionario funcionario in listafuncionarios)
                {
                    string linha = $"{funcionario._Id};{funcionario._Nome};{funcionario._Morada};{funcionario._Telefone};{funcionario._DataFim};{funcionario._DataRegisto}" +
                    $";{funcionario._Isencao};{funcionario._Bonus};{funcionario._Carro};{funcionario._Chefe};{funcionario._Area};{funcionario._Disponibilidade};{funcionario._ValorHora}";
                    sw.WriteLine(linha);
                }

                sw.Close();
            }


            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao escrever no arquivo: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Os dados foram atualizador no ficheiro Funcionarios.txt com sucesso!");
            }
        }

        public static void copiaNaoAlocados(List<Funcionario> listafuncionarios) //copia a lista de funcionários para o ficheiro funcionarios.txt
        {
            try
            {
                StreamWriter sw = new StreamWriter(@"NaoAlocados.txt");

                foreach (Funcionario funcionario in listafuncionarios)
                {
                    string linha = $"{funcionario._Id};{funcionario._Nome};{funcionario._Morada};{funcionario._Telefone};{funcionario._DataFim};{funcionario._DataRegisto}" +
                    $";{funcionario._Isencao};{funcionario._Bonus};{funcionario._Carro};{funcionario._Chefe};{funcionario._Area};{funcionario._Disponibilidade};{funcionario._ValorHora}";
                    sw.WriteLine(linha);
                }

                sw.Close();
            }


            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao escrever no arquivo: {ex.Message}");
            }
            Console.WriteLine("Dados atualizados em NaoAlocados.txt\n");
        }
        public void pagamento()
        {
            StreamReader sr = new StreamReader(@"Funcionarios.txt");
            string linha;
            string[] vec_fun;
            string id;
            string nome;
            string valorHora;
            string mes;
            bool ver = false;

            using (StreamWriter sp = new StreamWriter(@"Pagamentos.txt", true)) //usando o streamWriter sp
            {
                Console.WriteLine("Selecione o id do Funcionário: ");
                id = Console.ReadLine();

                if (!validaId(id)) //valida id inserido
                {
                    return;
                }

                Console.WriteLine("Selecione o mês: ");
                mes = Console.ReadLine();

                if (!validaMes(mes)) //valida mes inserido
                {
                    return;
                }

                foreach (Funcionario funcionario in funcionarios)
                {
                    if (funcionario._Id == id)
                    {
                        linha = sr.ReadLine();
                        vec_fun = linha.Split(';');
                        id = vec_fun[0];
                        nome = vec_fun[1];
                        valorHora = vec_fun[12];
                        Console.WriteLine("Pagamento Efetuado");
                        //calcula valor final
                        double valor = Convert.ToDouble(valorHora);
                        double salario = valor * 8 * 22;
                        salario = salario - (salario * 0.11);
                        salario = salario - (salario * 0.13);
                        salario = Math.Round(salario, 2); //arredonda salario apenas com duas casas decimais  
                        Console.WriteLine($"O salário do funcionário {nome} é de {salario} euros");
                        string frase = mes + ";" + id + ";" + nome + ";" + salario;
                        sp.WriteLine(frase); //escreve no ficheiro
                        ver = true;
                    }
                }
                if (!ver) //se a ver sai falso significa que o funcionario nao foi encontrado
                {
                    Console.WriteLine("Funcionário não encontrado");
                }
                sr.Close();
            }
            
        }
        public bool validaSemNumeros(string nome) //valida se a string tem numeros
        {

            foreach (char c in nome) //percorre o contacto
            {
                if (char.IsDigit(c)) //se encontrar um numero retorna falso
                {
                    Console.Clear();
                    Console.WriteLine("Adição cancelada\n");
                    Console.WriteLine("Não pode introduzir Numeros.");
                    return false;
                }
            }
            return true;
        }
        public bool validaId(string id) //valida se o Id tem letras
        {
            foreach (char c in id) //percorre o Id
            {
                if (char.IsLetter(c)) //se encontrar uma letra retorna falso
                {
                    Console.Clear();
                    Console.WriteLine("Adição cancelada");
                    Console.WriteLine("Não pode introduzir letras no ID.\n");
                    return false;
                }
            }
            return true;
        }
        public bool validaMes(string mes) //valida se o mes tem numeros
        {
            foreach (char c in mes) //percorre o mes
            {
                if (char.IsDigit(c)) //se encontrar uma letra retorna falso
                {
                    Console.Clear();
                    Console.WriteLine("Adição cancelada");
                    Console.WriteLine("Não pode introduzir numeros.\n");
                    return false;
                }
            }
            return true;
        }
    }

 }
    


