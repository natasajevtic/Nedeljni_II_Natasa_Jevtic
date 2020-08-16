using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using Zadatak_1.Models;

namespace Zadatak_1.Validations
{
    class UsernameValidation : ValidationRule
    {
        /// <summary>
        /// This method checks if user enter a valid and unique username.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string username = value as string;
            Users users = new Users();
            List<tblUser> userList = users.GetAllUsers();
            var user = userList.Where(x => x.Username == username).FirstOrDefault();
            //if exists user with forwarded username, return false
            if (user != null)
            {
                if (this.Wrapper != null)
                {
                    //if user editing
                    if (this.Wrapper.OldValue == user.Username)
                    {
                        return new ValidationResult(true, null);
                    }
                    //if user creating
                    else
                    {
                        return new ValidationResult(false, "This username already exists.");
                    }
                }
                else
                {
                    return new ValidationResult(false, "This username already exists.");
                }
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
        public Wrapper Wrapper { get; set; }
    }
}
