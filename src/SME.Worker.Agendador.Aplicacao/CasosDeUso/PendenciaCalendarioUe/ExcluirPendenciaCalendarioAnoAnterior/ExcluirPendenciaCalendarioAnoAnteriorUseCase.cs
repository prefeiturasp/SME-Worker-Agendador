using System;
using System.Threading.Tasks;
using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.PendenciaCalendarioUe.ExcluirPendenciaCalendarioAnoAnterior
{
    public class ExcluirPendenciaCalendarioAnoAnteriorUseCase : AbstractUseCase, IExcluirPendenciaCalendarioAnoAnteriorUseCase
    {
        public ExcluirPendenciaCalendarioAnoAnteriorUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar()
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.RotaExcluirPendenciaCalendarioAnoAnteriorCalendario,Guid.NewGuid()));
        }
    }
}