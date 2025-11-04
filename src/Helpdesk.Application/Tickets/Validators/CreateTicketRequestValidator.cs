using FluentValidation;
using Helpdesk.Contracts.Tickets;

namespace Helpdesk.Application.Tickets.Validators;

public class CreateTicketRequestValidator : AbstractValidator<CreateTicketRequest>
{
    public CreateTicketRequestValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(120);
        RuleFor(x => x.Description).MaximumLength(4000);
        RuleFor(x => x.ReporterId).NotEmpty();
    }
}
