using MediatR;
using Sentry;
using SME.Worker.Agendador.Dominio.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Dominio.CasosDeUso.PlanoAEE.EncerramentoPlanoAEEEstudantesInativos
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
