using MediatR;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Dominio.CasosDeUso.FilaTesteRabbitMQ
{
    public class FilaTesteRabbitMQ : AbstractUseCase, IFilaTesteRabbitMQ
    {
        public FilaTesteRabbitMQ(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            //await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.AlterarRecorrenciaEventos, Guid.NewGuid()));
            //await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.AlterarPeriodosComHierarquiaInferiorFechamento, Guid.NewGuid()));
            //await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.VerificarPendenciasFechamentoTurmaDisciplina, Guid.NewGuid()));
            //await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.GerarNotificacaoAlteracaoLimiteDias, Guid.NewGuid()));
            //await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.NotificarCompensacaoAusencia, Guid.NewGuid()));
            //await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.ExecutarGravarRecorrencia, Guid.NewGuid()));
            //await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.ExecutarTipoCalendario, Guid.NewGuid()));
            //await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.NotificacaoFrequencia, Guid.NewGuid()));
            //await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.DiarioBordoDaAulaExcluir, Guid.NewGuid()));
            //await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.AnotacoesFrequenciaDaAulaExcluir, Guid.NewGuid()));
            //await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.PlanoAulaDaAulaExcluir, Guid.NewGuid()));
            //await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.FrequenciaDaAulaExcluir, Guid.NewGuid()));
            //await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.NotificacoesDaAulaExcluir, Guid.NewGuid()));
            //await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.WorkflowAprovacaoExcluir, Guid.NewGuid()));
            //await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.NotificacoesNiveisCargos, Guid.NewGuid()));
            //await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.SincronizarComponentesCurriculares, Guid.NewGuid()));


        }
    }
}
