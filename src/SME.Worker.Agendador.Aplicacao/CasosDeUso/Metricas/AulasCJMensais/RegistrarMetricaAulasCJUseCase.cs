using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.Metricas
{
    public class RegistrarMetricaAulasCJUseCase : AbstractUseCase, IRegistrarMetricaAulasCJUseCase
    {
        public RegistrarMetricaAulasCJUseCase(IMediator mediator) : base(mediator)
        {
        }

        public Task Executar()
            => mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitMetricas.AulasCJMensais, Guid.NewGuid()));
    }
}
