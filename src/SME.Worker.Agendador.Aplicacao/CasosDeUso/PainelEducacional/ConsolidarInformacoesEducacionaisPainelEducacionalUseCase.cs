using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.PainelEducacional
{
    public class ConsolidarInformacoesEducacionaisPainelEducacionalUseCase : AbstractUseCase, IConsolidarInformacoesEducacionaisPainelEducacionalUseCase
    {
        public ConsolidarInformacoesEducacionaisPainelEducacionalUseCase(IMediator mediator) : base(mediator)
        {
        }
        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ConsolidarInformacoesEducacionaisPainelEducacionalUseCase", "Rabbit - ConsolidarInformacoesEducacionaisPainelEducacionalUseCase");
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ConsolidarEducacaoIntegralPainelEducacional, Guid.NewGuid()));
        }
    }
}
