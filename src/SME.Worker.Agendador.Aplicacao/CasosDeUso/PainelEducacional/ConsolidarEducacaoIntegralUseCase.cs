using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.PainelEducacional
{
    public class ConsolidarEducacaoIntegralUseCase : AbstractUseCase, IConsolidarEducacaoIntegralUseCase
    {
        public ConsolidarEducacaoIntegralUseCase(IMediator mediator) : base(mediator)
        {
        }
        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ConsolidarEducacaoIntegralUseCase", "Rabbit - ConsolidarEducacaoIntegralUseCase");
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ConsolidarEducacaoIntegralPainelEducacional, Guid.NewGuid()));
        }
    }
}
