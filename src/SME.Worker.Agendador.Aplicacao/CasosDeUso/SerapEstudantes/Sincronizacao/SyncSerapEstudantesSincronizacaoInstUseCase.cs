using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using SME.Worker.Agendador.Infra;
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
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSerap.RotaSincronizacaoInstitucional, Guid.NewGuid(), ExchangeRabbit.SerapEstudantes));
        }
    }
}
