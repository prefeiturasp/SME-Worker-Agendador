using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.PainelEducacional
{
    public class ConsolidarIdepPainelEducacionalUseCase : AbstractUseCase, IConsolidarIdepPainelEducacionalUseCase
    {
        public ConsolidarIdepPainelEducacionalUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ConsolidarIdepPainelEducacionalUseCase", "Rabbit - ConsolidarIdepPainelEducacionalUseCase");
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ConsolidarIdepPainelEducacional, Guid.NewGuid()));
        }
    }
}

