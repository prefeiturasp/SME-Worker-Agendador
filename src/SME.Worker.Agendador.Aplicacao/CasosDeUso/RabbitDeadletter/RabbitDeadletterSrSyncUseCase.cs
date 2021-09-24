using MediatR;
using SME.Worker.Agendador.Infra;
using SME.Worker.Agendador.Infra.Utilitarios;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.RabbitDeadletter
{
    public class RabbitDeadletterSrSyncUseCase : IRabbitDeadletterSrSyncUseCase
    {
        private readonly IMediator mediator;

        public RabbitDeadletterSrSyncUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task Executar()
        {
            foreach (var fila in typeof(RotasRabbitSgpRelatorios).ObterConstantesPublicas<string>())
            {
                await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.RotaRabbitSRDeadletterTratar, fila, Guid.NewGuid()));
            }
        }
    }
}
