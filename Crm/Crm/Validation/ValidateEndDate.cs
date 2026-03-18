using Entities;
using System.ComponentModel.DataAnnotations;

namespace Crm.Validation;

public class ValidateData
{
    /// <summary>
    /// Кастомная валидация даты окончания (должна быть не раньше даты начала)
    /// </summary>
    public static ValidationResult? ValidateEndDate(DateTime endDate, ValidationContext context)
    {
        var instance = (Contract)context.ObjectInstance;
        if (endDate < instance.StartDate)
        {
            return new ValidationResult("Дата окончания не может быть раньше даты начала", new[] { nameof(EndDate) });
        }
        return ValidationResult.Success;
    }

}