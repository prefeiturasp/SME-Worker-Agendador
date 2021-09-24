using System;

namespace SME.Worker.Agendador.Background.Core.Interfaces
{
    public interface IWorker : IDisposable
    {
        void Registrar();
    }
}
