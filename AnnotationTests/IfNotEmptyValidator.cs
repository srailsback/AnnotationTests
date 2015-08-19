using FluentValidation.Resources;
using FluentValidation.Validators;
using System.Collections;
using System.Linq;

namespace AnnotationTests
{

    public class IfNotEmptyValidator<T> : PropertyValidator {
        public IfNotEmptyValidator() : base("Property {PropertyName} is not a string.") { }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (context.PropertyValue is string)
            {
                return true;
            }
            return false;
        }
    }
}
