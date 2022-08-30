using FluentValidation;
using MediatR;

namespace SME.Worker.Agendador.Aplicacao
{
    public class PublicarFilaSerapAcompanhamentoCommand : IRequest<bool>
    {
        public PublicarFilaSerapAcompanhamentoCommand(string fila, object mensagem)
        {
            Fila = fila;
            Mensagem = mensagem;
        }

        public string Fila { get; set; }
        public object Mensagem { get; set; }
    }

    public class PublicarFilaSerapAcompanhamentoCommandCommandValidator : AbstractValidator<PublicarFilaSerapAcompanhamentoCommand>
    {
        public PublicarFilaSerapAcompanhamentoCommandCommandValidator()
        {
            RuleFor(c => c.Fila)
               .NotEmpty()
               .WithMessage("O nome da fila deve ser informado para publicar na fila do Serap estudantes.");

            RuleFor(c => c.Mensagem)
               .NotEmpty()
               .WithMessage("O objeto da mensagem ser informado para publicar na fila do Serap estudantes.");

        }
    }
}
