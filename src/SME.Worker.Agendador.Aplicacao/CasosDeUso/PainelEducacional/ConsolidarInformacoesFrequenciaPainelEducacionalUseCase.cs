using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.PainelEducacional
{
    public class ConsolidarInformacoesFrequenciaPainelEducacionalUseCase : AbstractUseCase, IConsolidarInformacoesFrequenciaPainelEducacionalUseCase
    {
        public ConsolidarInformacoesFrequenciaPainelEducacionalUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ConsolidarInformacoesFrequenciaPainelEducacionalUseCase", "Rabbit - ConsolidarInformacoesFrequenciaPainelEducacionalUseCase");

            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ConsolidarInformacoesFrequenciaPainelEducacional, Guid.NewGuid()));
        }
    }
}
