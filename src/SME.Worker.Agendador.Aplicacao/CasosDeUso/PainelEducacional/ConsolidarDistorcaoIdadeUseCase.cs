using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.PainelEducacional
{
    public class ConsolidarDistorcaoIdadeUseCase : AbstractUseCase, IConsolidarDistorcaoIdadeUseCase
    {
        public ConsolidarDistorcaoIdadeUseCase(IMediator mediator) : base(mediator)
        {
        }
        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ConsolidarDistorcaoIdadeUseCase", "Rabbit - ConsolidarDistorcaoIdadeUseCase");
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ConsolidarDistorcaoIdadePainelEducacional, Guid.NewGuid()));
        }
    }
}
