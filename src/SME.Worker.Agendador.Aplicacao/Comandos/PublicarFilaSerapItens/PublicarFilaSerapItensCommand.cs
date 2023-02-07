using FluentValidation;
using MediatR;

namespace SME.Worker.Agendador.Aplicacao
{
    public class PublicarFilaSerapItensCommand : IRequest<bool>
    {
        public PublicarFilaSerapItensCommand(string fila, object mensagem)
        {
            Fila = fila;
            Mensagem = mensagem;
        }

        public string Fila { get; set; }
        public object Mensagem { get; set; }

        public class PublicarFilaSerapItensCommandValidator : AbstractValidator<PublicarFilaSerapItensCommand>
        {
            public PublicarFilaSerapItensCommandValidator()
            {
                RuleFor(c => c.Fila)
                   .NotEmpty()
                   .WithMessage("O nome da fila deve ser informado para publicar na fila do Serap itens.");

                RuleFor(c => c.Mensagem)
                   .NotEmpty()
                   .WithMessage("O objeto da mensagem ser informado para publicar na fila do Serap itens.");

            }
        }

    }
}
