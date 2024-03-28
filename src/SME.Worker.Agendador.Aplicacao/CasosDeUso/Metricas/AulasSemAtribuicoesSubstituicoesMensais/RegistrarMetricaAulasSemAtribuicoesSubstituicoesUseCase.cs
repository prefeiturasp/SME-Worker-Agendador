using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.Metricas
{
    public class RegistrarMetricaAulasSemAtribuicoesSubstituicoesUseCase : AbstractUseCase, IRegistrarMetricaAulasSemAtribuicoesSubstituicoesUseCase
    {
        public RegistrarMetricaAulasSemAtribuicoesSubstituicoesUseCase(IMediator mediator) : base(mediator)
        {
        }

        public Task Executar()
            => mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitMetricas.AulasSemAtribuicaoSubstituicaoMensais, Guid.NewGuid()));
    }
}
