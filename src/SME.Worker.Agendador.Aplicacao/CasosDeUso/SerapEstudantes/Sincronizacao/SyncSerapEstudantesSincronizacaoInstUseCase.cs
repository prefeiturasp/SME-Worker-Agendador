using MediatR;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.SerapEstudantes
{
    public class SyncSerapEstudantesSincronizacaoInstUseCase : ISyncSerapEstudantesSincronizacaoInstUseCase
    {
        protected readonly IMediator mediator;

        public SyncSerapEstudantesSincronizacaoInstUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbitSerap.RotaSincronizacaoInstitucional, Guid.NewGuid()));
        }
    }
}
