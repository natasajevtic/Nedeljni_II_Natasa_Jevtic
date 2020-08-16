using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_1.Models
{
    class Shifts
    {
        /// <summary>
        /// This method created list of shifts.
        /// </summary>
        /// <returns>List of shifts.</returns>
        public List<string> GetShifts()
        {
            return new List<string> { "morning" , "afternoon" , "night" ,  "24 - hour duty" };
        }
    }
}
