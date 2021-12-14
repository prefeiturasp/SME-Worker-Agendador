using MediatR;
using SME.Worker.Agendador.Infra;
using System;

namespace SME.Worker.Agendador.Aplicacao.Comandos
{
    public class PublicaFilaRabbitCommand : IRequest<bool>
    {

        public PublicaFilaRabbitCommand(string rota, object filtros, Guid codigoCorrelacao, string exchange = "sme.sgp.workers")
        {
            Filtros = filtros;
            CodigoCorrelacao = codigoCorrelacao;
            NotificarErroUsuario = false;
            UsuarioLogadoNomeCompleto = null;
            UsuarioLogadoRF = null;
            PerfilUsuario = null;
            Rota = rota;
            Exchange = exchange ?? throw new ArgumentNullException(nameof(exchange));
        }

        public PublicaFilaRabbitCommand(string rota, Guid codigoCorrelacao, string exchange = "sme.sgp.workers")
        {
            Filtros = null;
            CodigoCorrelacao = codigoCorrelacao;
            NotificarErroUsuario = false;
            Rota = rota;
            UsuarioLogadoNomeCompleto = null;
            UsuarioLogadoRF = null;
            PerfilUsuario = null;
            Exchange = exchange ?? throw new ArgumentNullException(nameof(exchange));
        }

        public string Rota { get; set; }
        public object Filtros { get; set; }
        public Guid CodigoCorrelacao { get; set; }
        public string UsuarioLogadoNomeCompleto { get; set; }
        public string UsuarioLogadoRF { get; set; }
        public Guid? PerfilUsuario { get; set; }
        public bool NotificarErroUsuario { get; set; }
        public string Exchange { get; set; }
    }
}
