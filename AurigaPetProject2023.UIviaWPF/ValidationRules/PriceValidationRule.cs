
using System.Globalization;
using System.Windows.Controls;

namespace AurigaPetProject2023.UIviaWPF.ValidationRules
{
    public class PriceValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (string.IsNullOrWhiteSpace(value as string))
            {
                OnValidationFailed?.Invoke();
                return new ValidationResult(false, "Поле не может быть пустым.");
            }

            int result = 0;
            if (!int.TryParse((string)value, out result) || result <= 0)
            {
                OnValidationFailed?.Invoke();
                return new ValidationResult(false, "Поле должно быть целым числом больше нуля.");

            }
            return ValidationResult.ValidResult;
        }

        public event ValidationFailed OnValidationFailed;
    }

    public delegate void ValidationFailed();
}
