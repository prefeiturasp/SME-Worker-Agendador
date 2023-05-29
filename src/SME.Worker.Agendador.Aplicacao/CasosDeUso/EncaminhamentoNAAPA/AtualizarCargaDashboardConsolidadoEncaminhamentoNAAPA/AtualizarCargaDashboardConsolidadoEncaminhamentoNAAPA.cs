using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.EncaminhamentoNAAPA
{
    public class AtualizarCargaDashboardConsolidadoEncaminhamentoNAAPA : AbstractUseCase, IAtualizarCargaDashboardConsolidadoEncaminhamentoNAAPA
    {
        public AtualizarCargaDashboardConsolidadoEncaminhamentoNAAPA(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ExecutarCargaConsolidadoEncaminhamentoNAAPA, Guid.NewGuid()));
        }
    }
}
