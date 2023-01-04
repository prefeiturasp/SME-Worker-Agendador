using MediatR;
using Sentry;
using System;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Aplicacao
{
    public class IniciarImportacoesSerapItensUseCase : AbstractUseCase, IIniciarImportacoesSerapItensUseCase
    {
        public IniciarImportacoesSerapItensUseCase(IMediator mediator) : base(mediator){}

        public async Task<bool> Executar()
        {
            SentrySdk.AddBreadcrumb($"Mensagem IniciarImportacoesSerapItens", "Rabbit - IniciarImportacoesSerapItens");
            await mediator.Send(new PublicarFilaSerapItensCommand(RotasRabbitSerapItens.IniciarImportacoes, Guid.NewGuid()));
            return true;
        }
    }
}
