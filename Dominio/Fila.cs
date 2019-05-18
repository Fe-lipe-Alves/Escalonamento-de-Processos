using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Fila:IDisposable
    {
        #region Propriedades
        public int numero { get; set; }
        public int prioridade { get; set; }
        public int quantum { get; set; }
        public List<Processo> processos { get; set; }
        #endregion

        #region Métodos
        public void AdicionaProcesso(Processo processo)
        {
            if (this.processos == null)
            {
                this.processos = new List<Processo>();
                this.processos.Add(processo);
            }
            else
                this.processos.Add(processo);
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Contrutores
        public Fila()
        {
        }

        public Fila(int numero, int prioridade, int quantum)
        {
            this.numero = numero;
            this.prioridade = prioridade;
            this.quantum = quantum;
        }
        #endregion
    }
}
