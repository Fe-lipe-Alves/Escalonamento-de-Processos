using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Escalonador:IDisposable
    {
        #region Propriedades
        public List<Fila> filas { get; set; }
        public RoundRobin roundRobin { get; set; }
        #endregion

        #region Métodos
        public void AdicionarFila(Fila fila)
        {
            this.filas.Add(fila);

        }

        public void Dispose()
        {
            for (int i = 0; i < this.filas.Count; i++)
            {
                this.filas[i].Dispose();
            }
        }
        #endregion

        #region Contrutores
        public Escalonador(Fila fila, RoundRobin roundRobin)
        {
            this.filas = new List<Fila>();
            this.filas.Add(fila);
            this.roundRobin = roundRobin;
        }
        #endregion
    }
}
