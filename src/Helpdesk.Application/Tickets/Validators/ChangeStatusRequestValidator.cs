using FluentValidation;
using Helpdesk.Contracts.Tickets;

namespace Helpdesk.Application.Tickets.Validators;

public class ChangeStatusRequestValidator : AbstractValidator<ChangeStatusRequest>
{
    public ChangeStatusRequestValidator()
    {
        RuleFor(x => x.Status).IsInEnum();
    }
}
