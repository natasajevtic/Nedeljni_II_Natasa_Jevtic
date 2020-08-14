using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using Zadatak_1.Models;

namespace Zadatak_1.Validations
{
    class IdentityCardNumberValidation : ValidationRule
    {
        /// <summary>
        /// This method checks if user input for identity card number is valid and unique.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns>ValidationResult.</returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string number = value as string;
            if (number.Length == 9)
            {
                Users users = new Users();
                List<tblUser> userList = users.GetAllUsers();
                var user = userList.Where(x => x.IdentityCardNumber == number).FirstOrDefault();
                //if exists user with forwarded identity card number, return false
                if (user != null)
                {
                    if (this.Wrapper != null)
                    {
                        //if user editing
                        if (this.Wrapper.OldIdCardNumber == user.IdentityCardNumber)
                        {
                            return new ValidationResult(true, null);
                        }
                        //if user creating
                        else
                        {
                            return new ValidationResult(false, "This identity card already exists.");
                        }
                    }
                    else
                    {
                        return new ValidationResult(false, "This identity card already exists.");
                    }
                }
                else
                {
                    return new ValidationResult(true, null);
                }
            }
            else
            {
                return new ValidationResult(false, "Number must contain 9 digits.");
            }
        }
        public Wrapper Wrapper { get; set; }
    }
}
