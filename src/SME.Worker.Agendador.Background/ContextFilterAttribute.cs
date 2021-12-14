using Hangfire.Client;
using Hangfire.Common;
using Hangfire.Server;
using Microsoft.Extensions.DependencyInjection;
using SME.Worker.Agendador.Background.Core;
using SME.Worker.Agendador.Infra.Contexto;
using SME.Worker.Agendador.Infra.Escopo;
using SME.Worker.Agendador.Infra.Interfaces;

namespace SME.Worker.Agendador.Background
{
    public class ContextFilterAttribute : JobFilterAttribute,
    IClientFilter, IServerFilter
    {
        public void OnCreated(CreatedContext filterContext)
        {
            // Não preciso fazer nada aqui
        }

        public void OnCreating(CreatingContext filterContext)
        {
            IContextoAplicacao contexto = ObterContexto();
            if (contexto != null)
            {
                var contextoTransiente = new WorkerContext();
                contextoTransiente.AtribuirContexto(contexto);
                filterContext.SetJobParameter("contextoAplicacao", contextoTransiente);
            }
        }

        public void OnPerformed(PerformedContext filterContext)
        {
            WorkerServiceScope.DestroyScope();
        }

        public void OnPerforming(PerformingContext filterContext)
        {
            var contextoTransiente = filterContext.GetJobParameter<WorkerContext>("contextoAplicacao");
            WorkerServiceScope.TransientContexts.TryAdd(WorkerContext.ContextIdentifier, contextoTransiente);

        }

        private IContextoAplicacao ObterContexto()
        {
            var provider = Orquestrador.Provider;
            return provider.GetService<IContextoAplicacao>();
        }
    }
}
