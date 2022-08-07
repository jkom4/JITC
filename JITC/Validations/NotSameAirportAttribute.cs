using System.ComponentModel.DataAnnotations;

namespace JITC.Validations
{
    public class NotSameAirportAttribute : ValidationAttribute
    {
        public readonly string aeroportDepart;

        public string GetErrorMessage() => "l'aeroport de départ doit être différent de celui d'arrivé.";

        public NotSameAirportAttribute(string aeroportDepart)
        {
            this.aeroportDepart = aeroportDepart;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var propertyTestedInfo = validationContext.ObjectType.GetProperty(this.aeroportDepart);
            var propertyTestedValue = propertyTestedInfo.GetValue(validationContext.ObjectInstance, null);
            if ((int)value == (int)propertyTestedValue)
            {
                return new ValidationResult(GetErrorMessage());
            }
            return ValidationResult.Success;
        }
    }
}
