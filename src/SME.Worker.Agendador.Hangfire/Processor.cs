using Hangfire;
using Hangfire.Redis;
using SME.Worker.Agendador.Background;
using SME.Worker.Agendador.Background.Core.Interfaces;
using System;
using System.Linq.Expressions;

namespace SME.Worker.Agendador.Hangfire
{
    public class Processor : IProcessor
    {
        private readonly string connectionString;
        private readonly int redisDbNumber;

        public Processor(string connectionString, int redisDbNumber)
        {

            this.connectionString = connectionString;
            this.redisDbNumber = redisDbNumber;
        }

        public bool Registrado { get; private set; }

        public string Executar(Expression<Action> metodo)
        {
            return BackgroundJob.Enqueue(metodo);
        }

        public string Executar<T>(Expression<Action<T>> metodo)
        {
            return BackgroundJob.Enqueue<T>(metodo);
        }

        public void ExecutarPeriodicamente(Expression<Action> metodo, string cron)
        {
            RecurringJob.AddOrUpdate(metodo, cron);
        }

        public void ExecutarPeriodicamente<T>(Expression<Action<T>> metodo, string cron, string nomeFila = "default")
        {
            RecurringJob.AddOrUpdate(metodo, cron, queue: nomeFila);
        }

        public void Registrar()
        {
            var redisStorageOptions = new RedisStorageOptions() { Db = redisDbNumber };

            GlobalConfiguration.Configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseRedisStorage(connectionString, redisStorageOptions);

            GlobalJobFilters.Filters.Add(new ContextFilterAttribute());

            Registrado = true;
        }
    }
}