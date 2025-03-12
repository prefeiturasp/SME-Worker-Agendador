using FluentValidation;
using MediatR;

namespace SME.Worker.Agendador.Aplicacao.Comandos.PublicarFilaSerapBoletim
{
    public class PublicarFilaSerapBoletimCommand : IRequest<bool>
    {
        public PublicarFilaSerapBoletimCommand(string fila, object mensagem)
        {
            Fila = fila;
            Mensagem = mensagem;
        }

        public string Fila { get; set; }
        public object Mensagem { get; set; }
    }

    public class PublicarFilaSerapBoletimCommandValidator : AbstractValidator<PublicarFilaSerapBoletimCommand>
    {
        public PublicarFilaSerapBoletimCommandValidator()
        {
            RuleFor(c => c.Fila)
               .NotEmpty()
               .WithMessage("O nome da fila deve ser informado para publicar na fila do Serap boletim.");

            RuleFor(c => c.Mensagem)
               .NotEmpty()
               .WithMessage("O objeto da mensagem ser informado para publicar na fila do Serap boletim.");
        }
    }
}
