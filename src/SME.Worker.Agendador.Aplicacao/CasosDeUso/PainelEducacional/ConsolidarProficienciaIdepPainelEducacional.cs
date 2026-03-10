using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.PainelEducacional
{
    public class ConsolidarProficienciaIdepPainelEducacional : AbstractUseCase, IConsolidarProficienciaIdepPainelEducacional
    {
        public ConsolidarProficienciaIdepPainelEducacional(IMediator mediator) : base(mediator)
        {
        }
        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ConsolidarProficienciaIdepPainelEducacional", "Rabbit - ConsolidarProficienciaIdepPainelEducacional");
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ConsolidarProficienciaIdepPainelEducacional, Guid.NewGuid()));
        }
    }
}

