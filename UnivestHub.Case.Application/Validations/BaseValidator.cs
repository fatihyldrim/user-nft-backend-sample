using FluentValidation;

namespace UnivestHub.Case.Application.Validations
{
    public class BaseValidator<T> : AbstractValidator<T>
        where T : class, new()
    {
        public BaseValidator()
        {
            this.ClassLevelCascadeMode = CascadeMode.Continue;
        }
    }
}
