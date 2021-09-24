using StackExchange.Redis;

namespace SME.Worker.Agendador.Infra.Interfaces
{
    public interface IConnectionMultiplexerSME
    {
        IDatabase GetDatabase();
    }
}
