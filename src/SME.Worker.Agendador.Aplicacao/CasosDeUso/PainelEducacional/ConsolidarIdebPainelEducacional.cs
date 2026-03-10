using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.PainelEducacional
{
    public class ConsolidarIdebPainelEducacional : AbstractUseCase, IConsolidarIdebPainelEducacional
    {
        public ConsolidarIdebPainelEducacional(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ConsolidarIdebPainelEducacional", "Rabbit - ConsolidarIdebPainelEducacional");
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ConsolidarIdebPainelEducacional, Guid.NewGuid()));
        }
    }
}

