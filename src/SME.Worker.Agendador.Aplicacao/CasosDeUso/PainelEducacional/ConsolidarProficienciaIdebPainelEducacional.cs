using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.PainelEducacional
{
    public class ConsolidarProficienciaIdebPainelEducacional : AbstractUseCase, IConsolidarProficienciaIdebPainelEducacional
    {
        public ConsolidarProficienciaIdebPainelEducacional(IMediator mediator) : base(mediator)
        {
        }
        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ConsolidarProficienciaIdebPainelEducacional", "Rabbit - ConsolidarProficienciaIdebPainelEducacional");
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ConsolidarProficienciaIdebPainelEducacional, Guid.NewGuid()));
        }
    }
}

