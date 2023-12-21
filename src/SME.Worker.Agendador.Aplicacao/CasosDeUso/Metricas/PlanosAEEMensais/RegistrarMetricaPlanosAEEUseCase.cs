using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.Metricas
{
    public class RegistrarMetricaPlanosAEEUseCase : AbstractUseCase, IRegistrarMetricaPlanosAEEUseCase
    {
        public RegistrarMetricaPlanosAEEUseCase(IMediator mediator) : base(mediator)
        {
        }

        public Task Executar()
            => mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitMetricas.PlanosAEEMensais, new { Data = DateTime.Now.Date.AddDays(-1) }, Guid.NewGuid()));
    }
}
