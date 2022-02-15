using System.Globalization;
using System.Windows.Controls;

namespace Oponeo.WMS.WPFClient.ValidationRules
{
    internal class DocumentNumberValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string documentNumber)
            {
                if (string.IsNullOrWhiteSpace(documentNumber))
                    return new ValidationResult(false, "The field of the document number must be filled out");
                else if (documentNumber.Length < 10)
                    return new ValidationResult(false, "The field of the document number must have less than 10 characters");

                return new ValidationResult(true, string.Empty);
            }
            return new ValidationResult(false, "The value is not a string");
        }
    }
}
