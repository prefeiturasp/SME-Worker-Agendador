using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.PainelEducacional
{
    public class ConsolidarReclassificacaoPainelEducacionalUseCase : AbstractUseCase, IConsolidarReclassificacaoPainelEducacionalUseCase
    {
        public ConsolidarReclassificacaoPainelEducacionalUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ConsolidarReclassificacaoPainelEducacionalUseCase", "Rabbit - ConsolidarReclassificacaoPainelEducacionalUseCase");

            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ConsolidarReclassificacaoPainelEducacional, Guid.NewGuid()));
        }
    }
}
