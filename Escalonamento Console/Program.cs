using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Escalonamento_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            int numFila = 0;
            int prioridade;
            int quantum;
            int numProcesso = 0;
            String opc;

            numFila++;
            Fila novaFila = new Fila(numFila, 10, 1);
            Escalonador escalonador = new Escalonador(novaFila);

            // ---------------------------------------------------------------------------------------------------------------
            void exibeEscalonador()
            {
                Console.WriteLine("----------------------------------------------------------------------");
                foreach (var fila in escalonador.filas)
                {
                    Console.WriteLine("Fila "+fila.numero+" \\/");
                    if(fila.processos != null)
                    {
                        foreach (var processo in fila.processos)
                        {
                            Console.WriteLine("Processo -> " + processo.nome + " | PID -> " + processo.pid + " | Prioridade -> " + processo.prioridade + " | Tempo -> " + processo.tempo + " \\/");
                        }
                    }
                }
            }

            void trocafila()
            {
                Processo aux = null;

                for (int contadorFila = 0; contadorFila < escalonador.filas.Count; contadorFila++)
                {
                    if(aux != null)
                    {
                        if (escalonador.filas[contadorFila].processos.Count > 0)
                        {
                            for (int contadorProcesso = 0; contadorProcesso < escalonador.filas[contadorFila].processos.Count; contadorProcesso++)
                            {
                                aux = escalonador.filas[contadorFila].processos[contadorProcesso];
                            }
                        }
                    } else
                    {
                        escalonador.filas[contadorFila].AdicionaProcesso(aux);
                        aux = null;
                    }
                }
            }


            // ---------------------------------------------------------------------------------------------------------------
            do
            {
                Console.WriteLine("Escalonamento de Processos");
                Console.WriteLine("----------   Menu   ----------");
                Console.Write("Para adicionar um novo procesos digite 1. Para adicionar uma nova fila digite 2: ");
                opc = Console.ReadLine();

                if (opc == "1")
                {
                    Console.Write("Qual nome desse processo: ");
                    String nomeProcesso = Console.ReadLine();
                    
                    foreach (var fila in escalonador.filas)
                    {
                        if (fila.numero == 1)
                        {
                            numProcesso++;
                            Processo processo = new Processo(numProcesso, nomeProcesso, fila.prioridade, fila.quantum);
                            fila.AdicionaProcesso(processo);
                        }    
                    }
                }
                else if (opc == "2")
                {
                    Console.Write("Qual o quantum dessa nova fila: ");
                    quantum = int.Parse(Console.ReadLine());
                    Console.Write("Qual a prioridade dessa nova fila: ");
                    prioridade = int.Parse(Console.ReadLine());

                    numFila++;
                    Fila novafila = new Fila(numFila, prioridade, quantum);
                    escalonador.AdicionarFila(novafila);
                }
                else
                {
                    Console.WriteLine("Ops! Opção inválida. Digite outra.");
                }

                exibeEscalonador();
                trocafila();
            } while (opc != "0");



            // Não remova essa linha 'getch()'
            System.Console.ReadKey();

        }
    }
}
