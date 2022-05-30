using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.Devolutiva
{
    public class ReprocessarDiarioBordoPendenciaDevolutivaUseCase: AbstractUseCase, IReprocessarDiarioBordoPendenciaDevolutivaUseCase
    {
        public ReprocessarDiarioBordoPendenciaDevolutivaUseCase(IMediator mediator) : base(mediator){}

        public async Task Executar()
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.RotaReprocessarDiarioBordoPendenciaDevolutivaPorDre, DateTime.Now.Year, Guid.NewGuid()));
        }
    }
}
