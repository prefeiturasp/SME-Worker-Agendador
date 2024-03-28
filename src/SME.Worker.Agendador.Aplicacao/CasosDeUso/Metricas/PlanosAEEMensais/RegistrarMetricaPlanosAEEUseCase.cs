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
            => mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitMetricas.PlanosAEEMensais, Guid.NewGuid()));
    }
}
