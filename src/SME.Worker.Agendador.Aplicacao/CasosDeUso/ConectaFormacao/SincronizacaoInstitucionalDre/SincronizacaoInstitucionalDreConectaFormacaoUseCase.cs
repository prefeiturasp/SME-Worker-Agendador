using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;
using SME.Worker.Agendador.Aplicacao.Fila;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.ConectaFormacao.SincronizacaoInstitucionalDre
{
    public class SincronizacaoInstitucionalDreConectaFormacaoUseCase : AbstractUseCase, ISincronizacaoInstitucionalDreConectaFormacaoUseCase
    {
        public SincronizacaoInstitucionalDreConectaFormacaoUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> Executar()
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasConectaFormacao.SincronizaEstruturaInstitucionalDre, Guid.NewGuid()));
            return true;
        }
    }
}
