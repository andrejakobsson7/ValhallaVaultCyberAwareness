using System.ComponentModel.DataAnnotations;

namespace ValhallaVaultCyberAwareness.Client.Validators
{
    public class NotZeroAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (int.Parse(value.ToString()) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
