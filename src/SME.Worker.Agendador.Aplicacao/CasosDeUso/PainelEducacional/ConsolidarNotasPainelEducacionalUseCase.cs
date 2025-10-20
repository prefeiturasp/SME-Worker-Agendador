using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.PainelEducacional
{
    public class ConsolidarNotasPainelEducacionalUseCase : AbstractUseCase, IConsolidarNotasPainelEducacionalUseCase
    {
        public ConsolidarNotasPainelEducacionalUseCase(IMediator mediator) : base(mediator)
        {
        }
        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ConsolidarNotasPainelEducacionalUseCase", "Rabbit - ConsolidarNotasPainelEducacionalUseCase");
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ConsolidarNotasPainelEducacional, Guid.NewGuid()));
        }
    }
}