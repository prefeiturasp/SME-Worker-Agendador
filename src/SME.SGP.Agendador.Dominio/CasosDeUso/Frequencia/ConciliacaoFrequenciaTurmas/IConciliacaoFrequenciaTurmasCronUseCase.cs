using System;
using System.Threading.Tasks;

namespace SME.SGP.Agendador.Dominio.CasosDeUso.Frequencia.ConciliacaoFrequenciaTurmas
{
    public interface IConciliacaoFrequenciaTurmasCronUseCase
    {
        Task Executar();
        Task ProcessarNaData(DateTime dataPeriodo, string turmaCodigo);
    }
}
