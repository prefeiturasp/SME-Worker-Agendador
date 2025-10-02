using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.PainelEducacional
{
    public class ConsolidarSondagemEscritaPainelEducacionalUseCase : AbstractUseCase, IConsolidarSondagemEscritaPainelEducacionalUseCase
    {
        public ConsolidarSondagemEscritaPainelEducacionalUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ConsolidarSondagemEscritaPainelEducacionalUseCase", "Rabbit - ConsolidarSondagemEscritaPainelEducacionalUseCase");
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ConsolidarSondagemEscritaPainelEducacional, Guid.NewGuid()));
        }
    }
}

