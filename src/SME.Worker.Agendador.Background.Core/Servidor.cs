using SME.Worker.Agendador.Background.Core.Interfaces;
using System;

namespace SME.Worker.Agendador.Background.Core
{
    public class Servidor<T> : IDisposable
        where T : IWorker
    {
        readonly T worker;

        public Servidor(T worker)
        {
            this.worker = worker;
        }

        protected virtual void Dispose(bool disposing)
        {
            worker?.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Registrar()
        {
            worker.Registrar();
        }
    }
}
