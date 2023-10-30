using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.Metricas
{
    public class RegistrarMetricaFechamentoNotaDuplicadoUseCase : AbstractUseCase, IRegistrarMetricaFechamentoNotaDuplicadoUseCase
    {
        public RegistrarMetricaFechamentoNotaDuplicadoUseCase(IMediator mediator) : base(mediator)
        {
        }

        public Task Executar()
            => mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitMetricas.DuplicacaoFechamentoNota, Guid.NewGuid()));
    }
}
