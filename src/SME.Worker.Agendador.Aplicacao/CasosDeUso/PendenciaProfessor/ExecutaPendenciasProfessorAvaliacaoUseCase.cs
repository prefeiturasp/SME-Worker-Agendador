using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.PendenciaProfessor
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
