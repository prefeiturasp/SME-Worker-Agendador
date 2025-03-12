using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos.PublicarFilaSerapBoletim;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.ConsolidacaoBoletimProvaAluno
{
    public class ExecutarConsolidacaoBoletimProvaAlunoUseCase : AbstractUseCase,
        IExecutarConsolidacaoBoletimProvaAlunoUseCase
    {
        public ExecutarConsolidacaoBoletimProvaAlunoUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ExecutarConsolidacaoBoletimProvaAlunoUseCase", "Rabbit - ExecutarConsolidacaoBoletimProvaAlunoUseCase");

            await mediator.Send(new PublicarFilaSerapBoletimCommand(RotasRabbitSerapBoletim.BuscarProvasFinalizadas, string.Empty));
        }
    }
}
