using Core.Domain.Model;
using FluentValidation;
using Shared.Modelviews.ManTask;

namespace Manager.Validators
{
    public class NewManTaskValidator : AbstractValidator<NewManTask>
    {
        public NewManTaskValidator()    
        {
            RuleFor(x => x.Description).NotNull().NotEmpty().MinimumLength(10).MaximumLength(150);
            RuleFor(x => x.CollaboratorName).NotNull().NotEmpty().MinimumLength(3).MaximumLength(100);
            RuleFor(x => x.Comments).NotNull().NotEmpty().MinimumLength(10).MaximumLength(300);
            RuleFor(x => x.StartDate).NotNull().NotEmpty().GreaterThan(DateTime.Now);
            RuleFor(x => x.EndDate).NotNull().NotEmpty().GreaterThan(DateTime.Now.AddDays(10));
        }
    }
}