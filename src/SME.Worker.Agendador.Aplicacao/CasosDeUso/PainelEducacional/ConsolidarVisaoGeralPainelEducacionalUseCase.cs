using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.PainelEducacional
{
    public class ConsolidarVisaoGeralPainelEducacionalUseCase : AbstractUseCase, IConsolidarVisaoGeralPainelEducacionalUseCase
    {
        public ConsolidarVisaoGeralPainelEducacionalUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ConsolidarVisaoGeralPainelEducacionalUseCase", "Rabbit - ConsolidarVisaoGeralPainelEducacionalUseCase");
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ConsolidarVisaoGeralPainelEducacional, Guid.NewGuid()));
        }
    }
}

