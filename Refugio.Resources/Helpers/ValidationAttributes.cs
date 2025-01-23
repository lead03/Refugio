using Refugio.Resources.Languages;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Refugio.Resources.Helpers
{
    public class RequiredIfAttribute : ValidationAttribute
    {
        private readonly string _dependentProperty;
        private readonly object _expectedValue;
        private readonly bool _nullNotAllowed;

        public RequiredIfAttribute(string dependentProperty, object expectedValue, bool nullNotAllowed)
        {
            _dependentProperty = dependentProperty;
            _expectedValue = expectedValue;
            _nullNotAllowed = nullNotAllowed;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            System.Reflection.PropertyInfo dependentProperty = validationContext.ObjectType.GetProperty(this._dependentProperty);
            if (dependentProperty == null)
            {
                return new ValidationResult(string.Format(Global.DependentFieldNotConfigured, this._dependentProperty));
            }
            object dependentValue = dependentProperty.GetValue(validationContext.ObjectInstance, null);
            if (this._nullNotAllowed && dependentValue == null)
            {
                return new ValidationResult(string.Format(Global.DependentFieldInvalidValue, this._dependentProperty));
            }
            var displayAttribute = (dependentProperty.GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault() as DisplayAttribute).GetName();
            if (dependentValue != null && dependentValue.Equals(_expectedValue))
            {
                if (value == null || (value is string str && string.IsNullOrWhiteSpace(str)))
                {
                    var errorMessage = string.Format(
                        Global.RequiredIfMessage,
                        displayAttribute
                    );
                    return new ValidationResult(errorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
}