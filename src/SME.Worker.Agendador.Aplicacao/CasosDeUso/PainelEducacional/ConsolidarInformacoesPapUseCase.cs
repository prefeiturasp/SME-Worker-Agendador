using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.PainelEducacional
{
    public class ConsolidarInformacoesPapUseCase : AbstractUseCase, IConsolidarInformacoesPapUseCase
    {
        public ConsolidarInformacoesPapUseCase(IMediator mediator) : base(mediator)
        {
        }
        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ConsolidarInformacoesPapUseCase", "Rabbit - ConsolidarInformacoesPapUseCase");
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ConsolidarInformacoesPapPainelEducacional, Guid.NewGuid()));
        }
    }
}
