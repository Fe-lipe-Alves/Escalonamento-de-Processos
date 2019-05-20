using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Processo:IDisposable
    {
        public int pid { get; set; }
        public String nome { get; set; }
        public int prioridade { get; set; }
        public int burstTime { get; set; }

        public void DiminuirTempo(int tempoFila)
        {
            this.burstTime = this.burstTime - tempoFila;
            if (this.burstTime <= 0)
                this.Dispose();
        }

        public void AlterarPrioridade(int prioridade)
        {
            this.prioridade = this.prioridade - prioridade;
        }

        public void Dispose() { }

        public Processo() { }

        public Processo(int pid, string nome, int burstTime)
        {
            this.pid = pid;
            this.nome = nome;
            this.burstTime = burstTime;
        }
    }
}
