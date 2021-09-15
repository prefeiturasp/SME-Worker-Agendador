using MediatR;
using SME.SGP.Agendador.Dominio.Comandos;
using SME.SGP.Infra;
using SME.SGP.Infra.Utilitarios;
using System;
using System.Threading.Tasks;

namespace SME.SGP.Agendador.Dominio.CasosDeUso.RotasAgendamento
{
    public class RotasAgendamentoSyncUseCase : AbstractUseCase, IRotasAgendamentoSyncUseCase
    {
        public RotasAgendamentoSyncUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> Executar()
        {
            foreach (var fila in typeof(RotasRabbitSgpAgendamento).ObterConstantesPublicas<string>())
            {
                await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.RotaAgendamentoTratar, fila, Guid.NewGuid()));
            }

            return true;
        }
    }
}
