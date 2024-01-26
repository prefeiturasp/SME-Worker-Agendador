using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.Metricas
{
    public class RegistrarMetricaConselhoClasseAlunoDuplicadoUseCase : AbstractUseCase, IRegistrarMetricaConselhoClasseAlunoDuplicadoUseCase
    {
        public RegistrarMetricaConselhoClasseAlunoDuplicadoUseCase(IMediator mediator) : base(mediator)
        {
        }

        public Task Executar()
            => mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitMetricas.DuplicacaoConselhoClasseAluno, Guid.NewGuid()));
    }
}
