using JITC.Models;
using System.ComponentModel.DataAnnotations;

namespace JITC.Validations
{
    public class PiloteAttribute : ValidationAttribute

    {
        public string GetErrorMessage() => "Ce pilote n'est pas disponible Pour cet horaire";
        protected override  ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {   
                JITCDbContext db = (JITCDbContext)validationContext.GetService(typeof(JITCDbContext));
                var vol = (Vol)validationContext.ObjectInstance;
                var vols = db.Vol.Where(v => v.HeureDepartPrevue.Date == vol.HeureDepartPrevue.Date).Where(v => v.HeureDepartPrevue.TimeOfDay <= vol.HeureDepartPrevue.TimeOfDay || v.HeureArrivePrevue.TimeOfDay <= vol.HeureArrivePrevue.TimeOfDay).Where(v=> v.Id != vol.Id).ToList();
                var piloteId = ((string)value!);
                if (vols.Any())
                {
                    foreach (var item in vols)
                    {
                        if (item.PiloteId == piloteId)
                        {
                            return new ValidationResult(GetErrorMessage());
                        }
                    }
                }
            
            
            
            return ValidationResult.Success;
        }
    }
}
