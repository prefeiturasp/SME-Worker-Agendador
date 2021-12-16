using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.ConsolidacaoAcompanhamentoAprendizagemAluno
{
    public class ExecutarSincronizacaoAcompanhamentoAprendizagemAlunoSyncUseCase : AbstractUseCase, IExecutarSincronizacaoAcompanhamentoAprendizagemAlunoSyncUseCase
    {
        public ExecutarSincronizacaoAcompanhamentoAprendizagemAlunoSyncUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem ExecutarSincronizacaoAcompanhamentoAprendizagemAlunoSyncUseCase", "Rabbit - ExecutarSincronizacaoAcompanhamentoAprendizagemAlunoSyncUseCase");

            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.ConsolidarAcompanhamentoAprendizagemAluno, string.Empty, Guid.NewGuid()));
        }
    }
}
