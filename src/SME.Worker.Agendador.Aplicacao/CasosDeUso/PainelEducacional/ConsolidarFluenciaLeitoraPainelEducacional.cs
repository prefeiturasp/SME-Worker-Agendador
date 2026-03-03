using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.PainelEducacional
{
    public class ConsolidarFluenciaLeitoraPainelEducacional : AbstractUseCase, IConsolidarFluenciaLeitoraPainelEducacional
    {
        public ConsolidarFluenciaLeitoraPainelEducacional(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ConsolidarFluenciaLeitoraPainelEducacional", "Rabbit - ConsolidarFluenciaLeitoraPainelEducacional");
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ConsolidarFluenciaLeitoraPainelEducacional, Guid.NewGuid()));
        }
    }
}

