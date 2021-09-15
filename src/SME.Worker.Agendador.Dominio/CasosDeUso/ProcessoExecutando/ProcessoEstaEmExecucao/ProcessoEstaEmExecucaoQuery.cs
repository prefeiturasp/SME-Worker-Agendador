using MediatR;
using SME.Worker.Agendador.Dominio.Enumerados;

namespace SME.Worker.Agendador.Dominio.CasosDeUso.ProcessoExecutando.ProcessoEstaEmExecucao
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
