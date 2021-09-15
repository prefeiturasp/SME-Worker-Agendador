using MediatR;
using Sentry;
using SME.SGP.Agendador.Dominio.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.SGP.Agendador.Dominio.CasosDeUso.PendenciaAusenciaFechamento
{
    public class ExecutaPendenciasAusenciaFechamentoUseCase : AbstractUseCase, IExecutaPendenciasAusenciaFechamentoUseCase
    {
        public ExecutaPendenciasAusenciaFechamentoUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem PendenciasAusenciaFechamentoUseCase", "Rabbit - PendenciasAusenciaFechamentoUseCase");

            await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.RotaExecutaVerificacaoPendenciasAusenciaFechamento, Guid.NewGuid()));
        }
    }
}
