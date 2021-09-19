using MediatR;
using SME.SGP.Infra;
using SME.SGP.Infra.Utilitarios;
using SME.Worker.Agendador.Dominio.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Dominio.CasosDeUso.RabbitDeadletter
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
