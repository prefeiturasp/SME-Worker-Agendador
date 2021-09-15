using MediatR;
using SME.SGP.Agendador.Dominio.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.SGP.Agendador.Dominio.CasosDeUso.SerapEstudantes
{
    public class SyncSerapEstudantesProvasUseCase : ISyncSerapEstudantesProvasUseCase
    {
        protected readonly IMediator mediator;

        public SyncSerapEstudantesProvasUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.SyncSerapEstudantesProvas, Guid.NewGuid()));
        }
    }
}
