using MediatR;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao
{
    public class IniciarImportacoesSerapItensUseCase : AbstractUseCase, IIniciarImportacoesSerapItensUseCase
    {
        public IniciarImportacoesSerapItensUseCase(IMediator mediator) : base(mediator){}

        public async Task<bool> Executar()
        {
            await mediator.Send(new PublicarFilaSerapItensCommand(RotasRabbitSerapItens.IniciarImportacoes, Guid.NewGuid()));
            return true;
        }
    }
}
