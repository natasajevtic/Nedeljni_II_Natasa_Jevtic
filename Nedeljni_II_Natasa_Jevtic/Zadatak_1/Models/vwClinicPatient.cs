//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zadatak_1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class vwClinicPatient
    {
        public int UserId { get; set; }
        public string NameAndSurname { get; set; }
        public string IdentityCardNumber { get; set; }
        public string Gender { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string Citizenship { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public System.DateTime ExpirationDateOfHealthInsurance { get; set; }
        public string HealthInsuranceCardNumber { get; set; }
        public int PatientId { get; set; }
        public string UniqueNumberOfSelectedDoctor { get; set; }
    }
}
