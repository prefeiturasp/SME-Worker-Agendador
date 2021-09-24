using FluentValidation;
using MediatR;

namespace SME.Worker.Agendador.Aplicacao.CasosDeUso.ProcessoExecutando.RemoverProcessoEmExecucaoPorId
{
    public class RemoverProcessoEmExecucaoPorIdCommand : IRequest<bool>
    {
        public RemoverProcessoEmExecucaoPorIdCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }

    public class RemoverProcessoEmExecucaoPorIdCommandValidator : AbstractValidator<RemoverProcessoEmExecucaoPorIdCommand>
    {
        public RemoverProcessoEmExecucaoPorIdCommandValidator()
        {
            RuleFor(a => a.Id)
               .NotEmpty()
               .WithMessage("O id do processo deve ser informado para exclusão.");
        }
    }
}
