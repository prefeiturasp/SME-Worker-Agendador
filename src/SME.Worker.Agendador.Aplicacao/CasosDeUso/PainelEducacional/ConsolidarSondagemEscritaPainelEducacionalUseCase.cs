using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.PainelEducacional
{
    public class ConsolidarSondagemEscritaUePainelEducacionalUseCase : AbstractUseCase, IConsolidarSondagemEscritaUePainelEducacionalUseCase
    {
        public ConsolidarSondagemEscritaUePainelEducacionalUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ConsolidarSondagemEscritaUePainelEducacionalUseCase", "Rabbit - ConsolidarSondagemEscritaUePainelEducacionalUseCase");
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ConsolidarSondagemEscritaUePainelEducacional, Guid.NewGuid()));
        }
    }
}

