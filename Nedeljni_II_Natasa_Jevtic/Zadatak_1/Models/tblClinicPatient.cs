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
    
    public partial class tblClinicPatient
    {
        public int PatientId { get; set; }
        public int UserId { get; set; }
        public string HealthInsuranceCardNumber { get; set; }
        public System.DateTime ExpirationDateOfHealthInsurance { get; set; }
        public string UniqueNumberOfSelectedDoctor { get; set; }
    
        public virtual tblUser tblUser { get; set; }
    }
}
