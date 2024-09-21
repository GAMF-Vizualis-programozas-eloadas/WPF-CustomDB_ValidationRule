using System.Windows.Controls;

namespace CustomDB_ValidationRule
{
	class vrAverage : ValidationRule
	{
		public override System.Windows.Controls.ValidationResult Validate(
			object value, System.Globalization.CultureInfo cultureInfo)
		{
			// Valós értéket adott meg a felhasználó?
			if (!double.TryParse((string)value, out double Average))
				return new ValidationResult(false, "Not a number!");
			// A megfelelő szélsőértékek közé esik az érték.
			if (Average<1 || Average>5)
				return new ValidationResult(false, "Value out of bounds!");
			// Az érték jó.
			return new ValidationResult(true, null);
		}
	}
}
