using MediatR;
using Sentry;
using SME.Worker.Agendador.Dominio.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Dominio.CasosDeUso.PendenciaProfessor
{
    public class ExecutaPendenciasProfessorAvaliacaoUseCase : AbstractUseCase, IExecutaPendenciasProfessorAvaliacaoUseCase
    {
        public ExecutaPendenciasProfessorAvaliacaoUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem PendenciasProfessorUseCase", "Rabbit - PendenciasProfessorUseCase");

            await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.RotaExecutaVerificacaoPendenciasProfessor, Guid.NewGuid()));
        }
    }
}
