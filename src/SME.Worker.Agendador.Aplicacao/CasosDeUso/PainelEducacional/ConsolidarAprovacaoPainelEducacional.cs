using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.PainelEducacional
{
    public class ConsolidarAprovacaoPainelEducacional : AbstractUseCase, IConsolidarAprovacaoPainelEducacional
    {
        public ConsolidarAprovacaoPainelEducacional(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ConsolidarAprovacaoPainelEducacional", "Rabbit - ConsolidarAprovacaoPainelEducacional");
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ConsolidarAprovacaoPainelEducacional, Guid.NewGuid()));
        }
    }
}

