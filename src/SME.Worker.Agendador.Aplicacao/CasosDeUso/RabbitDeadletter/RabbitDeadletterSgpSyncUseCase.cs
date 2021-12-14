using MediatR;
using SME.Worker.Agendador.Infra.Utilitarios;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.RabbitDeadletter
{
    public class RabbitDeadletterSgpSyncUseCase : IRabbitDeadletterSgpSyncUseCase
    {
        private readonly IMediator mediator;

        public RabbitDeadletterSgpSyncUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar()
        {
            foreach (var fila in typeof(RotasRabbitSgp).ObterConstantesPublicas<string>())
            {
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.RotaRabbitDeadletterTratar, fila, Guid.NewGuid()));
            }

            return true;
        }
    }
}
