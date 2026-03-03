using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.PainelEducacional
{
    public class ConsolidarFrequenciaSemanalPainelEducacional : AbstractUseCase, IConsolidarFrequenciaSemanalPainelEducacional
    {
        public ConsolidarFrequenciaSemanalPainelEducacional(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ConsolidarFrequenciaSemanalPainelEducacional", "Rabbit - ConsolidarFrequenciaSemanalPainelEducacional");
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ConsolidarFrequenciaSemanalPainelEducacional, Guid.NewGuid()));
        }
    }

}

