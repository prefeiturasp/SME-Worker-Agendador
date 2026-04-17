using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SME.Worker.Agendador.Background.Core.Interfaces
{
    public interface IProcessor
    {
        bool Registrado { get; }
        string Executar(Expression<Action> metodo);

        string Executar<T>(Expression<Action<T>> metodo); 
        string Executar<T>(Expression<Func<T, Task>> metodo);

        void ExecutarPeriodicamente(Expression<Action> metodo, string cron);

        void ExecutarPeriodicamente<T>(Expression<Action<T>> metodo, string cron, string nomeFila = "default");
        void ExecutarPeriodicamente<T>(Expression<Func<T, Task>> metodo, string cron, string nomeFila = "default");

        void Registrar();
    }
}