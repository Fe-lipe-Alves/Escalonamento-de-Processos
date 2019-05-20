using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class RoundRobin:IDisposable
    {
        #region Propriedades
        public int quantum { get; set; }
        public int prioridade { get; set; }
        public List<Processo> processos { get; set; }
        #endregion

        #region Métodos
        public void AdicionaProcesso(Processo processoAdd)
        {
            if (this.processos == null)
                this.processos = new List<Processo>();
            this.processos.Add(processoAdd);
        }

        public void Dispose() { }


        #endregion

        #region Construtores
        public RoundRobin() { }

        public RoundRobin(int quantum, int prioridade)
        {
            this.quantum = quantum;
            this.prioridade = prioridade;
        }


        #endregion
    }
}
