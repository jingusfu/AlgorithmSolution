using System.ComponentModel.DataAnnotations;

namespace StudentRestAPI.Validation
{
    public class DateBeforeTodayAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateOnly date)
            {
                return date < DateOnly.FromDateTime(DateTime.Today);
            }

            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"{name} must be a date before today.";
        }
    }
}
