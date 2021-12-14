using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.PendenciaAusenciaFechamento
{
    public class ExecutaPendenciasAusenciaFechamentoUseCase : AbstractUseCase, IExecutaPendenciasAusenciaFechamentoUseCase
    {
        public ExecutaPendenciasAusenciaFechamentoUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem PendenciasAusenciaFechamentoUseCase", "Rabbit - PendenciasAusenciaFechamentoUseCase");

            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.RotaExecutaVerificacaoPendenciasAusenciaFechamento, Guid.NewGuid()));
        }
    }
}
