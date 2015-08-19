using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnotationTests
{
    public class SegmentEditValidator : AbstractValidator<SegmentEdit>
    {
        public SegmentEditValidator()
        {
            // RuleFor(x => x.ROUTE).NotEmpty().When(y => y.FIPS != "" || y.FIPS != null).WithMessage("ROUTE is required.");

            // FIPS all digits, 3 or 5 characters long, no alphas
            RuleFor(x => x.FIPS).NotEmpty().WithMessage("FIPS is required.");
            RuleFor(x => x.FIPS).Matches(@"^(\d{3})$|^(\d{5})$").WithMessage("FIPS must be 3 or 5 characters long and cannot contain letters.");

            // ROUTE, required, max length 11 characters
            RuleFor(x => x.ROUTE).NotEmpty().WithMessage("ROUTE is required.");
            RuleFor(x => x.ROUTE).Length(1, 11).WithMessage("ROUTE cannot exceed 11 characters.");

            // SEGMPREFIX, not required, but if giving valid values are N, S, E, W
            RuleFor(x => x.SEGMPREFIX).Matches(@"^[NWES]{1}|^$").WithMessage("SEGMENT PREFIX must be N, W, E, W, or empty value.");

        }
    }
}
