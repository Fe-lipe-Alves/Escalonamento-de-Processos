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
        #endregion

        #region Métodos
        public void AdicionarFila(Fila fila)
        {
            this.filas.Add(fila);

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Contrutores
        public Escalonador(Fila fila)
        {
            this.filas = new List<Fila>();
            this.filas.Add(fila);
        }
        #endregion
    }
}
