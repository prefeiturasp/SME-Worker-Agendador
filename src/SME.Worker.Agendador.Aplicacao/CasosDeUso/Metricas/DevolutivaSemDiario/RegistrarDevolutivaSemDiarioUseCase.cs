using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.Metricas.DevolutivaSemDiario
{
    public class RegistrarDevolutivaSemDiarioUseCase : AbstractUseCase, IRegistrarDevolutivaSemDiarioUseCase
    {
        public RegistrarDevolutivaSemDiarioUseCase(IMediator mediator) : base(mediator)
        {
        }

        public Task Executar()
            => mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitMetricas.DevolutivaSemDiario, Guid.NewGuid()));
    }
}
