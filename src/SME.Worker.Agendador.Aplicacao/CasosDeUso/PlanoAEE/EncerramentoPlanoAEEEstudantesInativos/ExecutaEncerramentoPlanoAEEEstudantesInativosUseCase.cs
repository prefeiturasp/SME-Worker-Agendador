using MediatR;
using Sentry;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.PlanoAEE.EncerramentoPlanoAEEEstudantesInativos
{
    public class ExecutaEncerramentoPlanoAEEEstudantesInativosUseCase : AbstractUseCase, IExecutaEncerramentoPlanoAEEEstudantesInativosUseCase
    {
        public ExecutaEncerramentoPlanoAEEEstudantesInativosUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem EncerrarPlanoAEEEstudantesInativosUseCase", "Rabbit - EncerrarPlanoAEEEstudantesInativosUseCase");

            await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.EncerrarPlanoAEEEstudantesInativos, Guid.NewGuid()));
        }
    }
}
