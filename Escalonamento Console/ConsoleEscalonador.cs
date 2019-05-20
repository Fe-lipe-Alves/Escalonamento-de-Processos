using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Escalonamento_Console
{
    public class ConsoleEscalonador
    {
        static void Main(string[] args)
        {
            // Variáveis necessárias para a crição de filas
            int numFila = 1;
            int prioridade;
            int quantum;

            // Variável necessária para a criação de processos
            int numProcesso = 0;

            // Variáveis gerais
            String opc;

            // Instancia o escalonador passando uma fila (obrigatória) e o Round Robin
            Fila fila1 = new Fila(numFila, 10, 1);
            RoundRobin roundRobin = new RoundRobin(1, 10);
            Escalonador escalonador = new Escalonador(fila1, roundRobin);

            // ------------------------------------------------------------   FUNÇÕES   ------------------------------------------------------------

            // Exibe todas as filas com seus respectivos processos
            void exibeEscalonador()
            {
                Console.Clear();
                Console.WriteLine("------------------------------ Enquanto isso no Escalonador ------------------------------");
                // Percorre as Filas
                foreach (var fila in escalonador.filas)
                {
                    Console.WriteLine("Fila " + fila.numero + " :");
                    // Caso existir, percorre e exibe os processos da fila 
                    if (fila.processos != null)
                    {
                        foreach (var processo in fila.processos)
                        {
                            Console.WriteLine("Processo -> " + processo.nome + " | PID -> " + processo.pid + " | Prioridade -> " + processo.prioridade + " | Tempo -> " + processo.burstTime + " \\/");
                        }
                    }
                }

                Console.WriteLine("RoundRobin :");
                if(escalonador.roundRobin.processos != null)
                {
                    int maiorTempo = 0;
                    while(maiorTempo > 0)
                    {
                        foreach (var processoEmExecucao in escalonador.roundRobin.processos)
                        {
                            if (processoEmExecucao.burstTime > maiorTempo)
                                maiorTempo = processoEmExecucao.burstTime;
                            processoEmExecucao.DiminuirTempo(escalonador.roundRobin.quantum);
                        }
                    }
                }
            }

            void exibeMenu()
            {
                // Exibe o menu de opções e faz a leitura da resposta do usuário
                Console.WriteLine("\n\n\n------------  Escalonamento de Processos  ------------\n");
                Console.WriteLine("                         Menu                         \n");
                Console.Write("Adicionar Processos ( 1 ). Adicionar Fila  ( 2 ): ");
                opc = Console.ReadLine();

                // Direciona para criar um procesos (1) ou uma fila (2)
                if (opc == "1")
                {
                    // Lê o nome que o usuário quer dar ao processo
                    Console.Write("--Qual nome desse processo: ");
                    String nomeProcesso = Console.ReadLine();
                    Console.Write("--Qual Burst Time desse processo (inteiro): ");
                    int burstTime = int.Parse(Console.ReadLine());

                    // Cria um processo e o adiciona na primeira fila 
                    numProcesso++;
                    Processo processoAdd = new Processo(numProcesso, nomeProcesso, burstTime);
                    escalonador.filas[0].AdicionaProcesso(processoAdd);

                    executaQuantum();
                }
                else if (opc == "2")
                {
                    // Lê o quantum e a prioridade da nova fila
                    Console.Write("--Qual o quantum dessa nova fila: ");
                    quantum = int.Parse(Console.ReadLine());
                    Console.Write("--Qual a prioridade dessa nova fila: ");
                    prioridade = int.Parse(Console.ReadLine());

                    // Instancia uma nova fila e a adiciona ao escalonador
                    numFila++;
                    Fila novafila = new Fila(numFila, prioridade, quantum);
                    escalonador.AdicionarFila(novafila);
                }
                else
                {
                }
            }

            // O processo sai de uma fila e vai para a fila posterior
            void executaQuantum()
            {
                Processo auxProcesso;
                for (int contFila = 0; contFila < escalonador.filas.Count; contFila++)
                {
                    // Verifica se foi instanciado um processo na fila atual e se existe algum a ser executado
                    if (escalonador.filas[contFila].processos != null)
                    {
                        if (escalonador.filas[contFila].processos.Count > 0)
                        {
                            while (escalonador.filas[contFila].processos.Count > 0)
                            {
                                exibeEscalonador();
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));

                                // Remove o processo da fila atual
                                auxProcesso = escalonador.filas[contFila].RemoveProcesso();
                                auxProcesso.DiminuirTempo(escalonador.filas[contFila].quantum);

                                // Verifica se está na ultima fila, se estiver insere o processo no Round Robin
                                if ((escalonador.filas.Count - 1) == contFila)
                                {
                                    if (auxProcesso != null)
                                    {
                                        escalonador.roundRobin.AdicionaProcesso(auxProcesso);

                                    }
                                }
                                // Se não estiver na ultima fila, insere o processo na fila posterior
                                else
                                {
                                    if (auxProcesso != null)
                                    {
                                        escalonador.filas[contFila + 1].AdicionaProcesso(auxProcesso);
                                    }
                                }
                                exibeMenu();
                            }
                        }
                    }
                }
            }

            // ------------------------------------------------------------   PROGRAMA EM EXECUÇÃO   ------------------------------------------------------------
            do
            {
                exibeEscalonador();
                exibeMenu();
                executaQuantum();
            } while (1==1);
        }
    }
}
