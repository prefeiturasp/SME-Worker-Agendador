using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.Metricas
{
    public class RegistrarMetricaPlanosAulaUseCase : AbstractUseCase, IRegistrarMetricaPlanosAulaUseCase
    {
        public RegistrarMetricaPlanosAulaUseCase(IMediator mediator) : base(mediator)
        {
        }

        public Task Executar()
            => mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitMetricas.PlanosAulaDiarios, new { Data = DateTime.Now.Date.AddDays(-1) }, Guid.NewGuid()));
    }
}
