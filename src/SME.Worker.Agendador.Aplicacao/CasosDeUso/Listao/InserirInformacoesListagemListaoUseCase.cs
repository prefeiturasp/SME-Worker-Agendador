using System;
using System.Threading.Tasks;
using MediatR;
using SME.Worker.Agendador.Aplicacao.Comandos;

namespace SME.Worker.Agendador.Aplicacao;

public class InserirInformacoesListagemListaoUseCase : AbstractUseCase, IInserirInformacoesListagemListaoUseCase
{
    public InserirInformacoesListagemListaoUseCase(IMediator mediator) : base(mediator)
    {
    }
    
    public async Task Executar()
    {
        await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.InserirInformacoesListagemDoListaoSync, Guid.NewGuid()));
    }
}