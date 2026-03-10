using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.PainelEducacional
{
    public class ConsolidarPlanosAEEUseCase : AbstractUseCase, IConsolidarPlanosAEEUseCase
    {
        public ConsolidarPlanosAEEUseCase(IMediator mediator) : base(mediator)
        {
        }
        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ConsolidarPlanosAEEUseCase", "Rabbit - ConsolidarDistorcaoIdadeUseCase");
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ConsolidarPlanosAEEPainelEducacional, Guid.NewGuid()));
        }
    }
}
