using System.ComponentModel.DataAnnotations;

namespace ValhallaVaultCyberAwareness.Client.Validators
{
	public class IsBoolAttribute : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			if (value == null)
				return false;

			if (value.GetType() != typeof(bool))
				return false;

			return (bool)value;
		}
	}
}
