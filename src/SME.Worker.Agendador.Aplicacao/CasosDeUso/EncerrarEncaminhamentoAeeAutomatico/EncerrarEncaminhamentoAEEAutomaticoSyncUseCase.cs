using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.EncerrarEncaminhamentoAeeAutomatico
{
    public class EncerrarEncaminhamentoAEEAutomaticoSyncUseCase : AbstractUseCase, IEncerrarEncaminhamentoAEEAutomaticoSyncUseCase
    {
        public EncerrarEncaminhamentoAEEAutomaticoSyncUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.EncerrarEncaminhamentoAEEAutomaticoSync, string.Empty, Guid.NewGuid()));
        }
    }
}
