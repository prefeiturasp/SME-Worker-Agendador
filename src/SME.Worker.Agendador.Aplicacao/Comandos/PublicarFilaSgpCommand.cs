using MediatR;
using System;

namespace SME.Worker.Agendador.Aplicacao.Comandos
{
    public class PublicarFilaSgpCommand : IRequest<bool>
    {
        public PublicarFilaSgpCommand(string rota, object filtros, Guid codigoCorrelacao, (string Nome, string CodigoRf, Guid PerfilAtual) usuarioLogado, bool notificarErroUsuario = false)
        {
            Filtros = filtros;
            CodigoCorrelacao = codigoCorrelacao;
            NotificarErroUsuario = notificarErroUsuario;
            UsuarioLogadoNomeCompleto = usuarioLogado.Nome;
            UsuarioLogadoRF = usuarioLogado.CodigoRf;
            PerfilUsuario = usuarioLogado.PerfilAtual;
            Rota = rota;
        }

        public PublicarFilaSgpCommand(string rota, object filtros, Guid codigoCorrelacao)
        {
            Filtros = filtros;
            CodigoCorrelacao = codigoCorrelacao;
            NotificarErroUsuario = false;
            UsuarioLogadoNomeCompleto = null;
            UsuarioLogadoRF = null;
            PerfilUsuario = null;
            Rota = rota;
        }

        public PublicarFilaSgpCommand(string rota, Guid codigoCorrelacao)
        {
            Filtros = null;
            CodigoCorrelacao = codigoCorrelacao;
            NotificarErroUsuario = false;
            Rota = rota;
            UsuarioLogadoNomeCompleto = null;
            UsuarioLogadoRF = null;
            PerfilUsuario = null;
        }

        public string Rota { get; set; }
        public object Filtros { get; set; }
        public Guid CodigoCorrelacao { get; set; }
        public string UsuarioLogadoNomeCompleto { get; set; }
        public string UsuarioLogadoRF { get; set; }
        public Guid? PerfilUsuario { get; set; }
        public bool NotificarErroUsuario { get; set; }
    }
}
