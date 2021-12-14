using MediatR;
using SME.Worker.Agendador.Aplicacao.Enumerados;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.ProcessoExecutando.ProcessoEstaEmExecucao
{
    public class ProcessoEstaEmExecucaoQuery : IRequest<bool>
    {
        public ProcessoEstaEmExecucaoQuery(TipoProcesso tipoProcesso)
        {
            TipoProcesso = tipoProcesso;
        }

        public TipoProcesso TipoProcesso { get; set; }
    }
}
