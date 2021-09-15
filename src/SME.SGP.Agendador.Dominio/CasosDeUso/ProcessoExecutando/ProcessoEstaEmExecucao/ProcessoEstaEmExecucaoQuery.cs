using MediatR;
using SME.SGP.Agendador.Dominio.Enumerados;

namespace SME.SGP.Agendador.Dominio.CasosDeUso.ProcessoExecutando.ProcessoEstaEmExecucao
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
