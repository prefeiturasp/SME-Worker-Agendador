using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.PainelEducacional
{
    public class ConsolidarFrequenciaDiariaPainelEducacional : AbstractUseCase, IConsolidarFrequenciaDiariaPainelEducacional
    {
        public ConsolidarFrequenciaDiariaPainelEducacional(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ConsolidarFrequenciaDiariaPainelEducacional", "Rabbit - ConsolidarFrequenciaDiariaPainelEducacional");
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ConsolidarFrequenciaDiariaPainelEducacional, Guid.NewGuid()));
        }
    }
}

