using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Processo
    {
        public int pid { get; set; }
        public String nome { get; set; }
        public int prioridade { get; set; }
        public int tempo { get; set; }

        public void DiminuirTempo(int tempoFila)
        {
            this.tempo = this.tempo - tempoFila;
        }

        public void AlterarPrioridade(int prioridade)
        {
            this.prioridade = this.prioridade - prioridade;
        }

        public Processo()
        {
        }

        public Processo(int pid, string nome, int prioridade, int tempo)
        {
            this.pid = pid;
            this.nome = nome;
            this.prioridade = prioridade;
            this.tempo = tempo;
        }
    }
}
