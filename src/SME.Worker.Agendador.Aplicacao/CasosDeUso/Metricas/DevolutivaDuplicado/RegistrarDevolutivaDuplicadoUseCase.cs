using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.Metricas.DevolutivaDuplicado
{
    public class RegistrarDevolutivaDuplicadoUseCase : AbstractUseCase, IRegistrarDevolutivaDuplicadoUseCase
    {
        public RegistrarDevolutivaDuplicadoUseCase(IMediator mediator) : base(mediator)
        {
        }

        public Task Executar()
            => mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitMetricas.DuplicadoDevolutiva, Guid.NewGuid()));
    }
}
