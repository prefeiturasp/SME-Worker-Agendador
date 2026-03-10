using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.PainelEducacional
{
    public class ConsolidarAbandonoPainelEducacional : AbstractUseCase, IConsolidarAbandonoPainelEducacional
    {
        public ConsolidarAbandonoPainelEducacional(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ConsolidarAbandonoPainelEducacional", "Rabbit - ConsolidarAbandonoPainelEducacional");
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ConsolidarAbandonoPainelEducacional, Guid.NewGuid()));
        }
    }
}

