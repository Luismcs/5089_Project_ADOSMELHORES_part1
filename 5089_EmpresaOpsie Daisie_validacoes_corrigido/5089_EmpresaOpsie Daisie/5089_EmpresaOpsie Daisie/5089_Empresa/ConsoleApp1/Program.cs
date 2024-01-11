namespace ConsoleApp1
{
    internal class Program
    {
 
            static void menu() //menu da empresa
            {
                string op;

                Console.WriteLine("----Menu----");
                Console.WriteLine("1-Mostrar lista de funcionários");
                Console.WriteLine("2-Mostrar lista de horários");
                Console.WriteLine("3-Alocar funcionario a um horario");
                Console.WriteLine("4-Mostrar gastos da Empresa");
                Console.WriteLine("5-Mostrar funcionários não alocados");
                Console.WriteLine("6-Pagamento de salários");
                Console.WriteLine("7-Adicionar funcionário");   
                Console.ForegroundColor = ConsoleColor.Red; //altera cor para vermelho
                Console.WriteLine("0-Sair");
                Console.ForegroundColor = ConsoleColor.Gray; //altera cor para branco

            }


            static void Main(string[] args)
            {
                string op = "";
                Empresa ADOSMELHORES = new Empresa();
                ADOSMELHORES.LerFicheiro();



                while (op != "0")
                {
                    menu();
                    Console.WriteLine("Insira a opcao: ");
                    op = Console.ReadLine();
                    Console.Clear(); //limpa a consola

                    switch (op)
                    {
                        case "1":
                            ADOSMELHORES.imprimeFuncionarios();
                            break;
                        case "2":
                            ADOSMELHORES.imprimeHorarios();
                            break;
                        case "3":
                            ADOSMELHORES.alocar();
                            break;
                        case "4":
                            ADOSMELHORES.GastosEmpresa();
                            break;
                        case "5":
                            ADOSMELHORES.naoAlocados();
                            break;
                        case "0":
                            Console.WriteLine("A sair...");
                            return;
                        case "6":
                             ADOSMELHORES.pagamento();
                             break;
                        case "7":   
                            ADOSMELHORES.adicionaFun();
                            break;
                        default:
                            Console.WriteLine("Introduza uma opção válida\n");
                            break;
                    }
                }


            }

            //Falta alterar o tipo de horario no ficheiro de funcionarios.txt

        }
    }
    