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
    
    public partial class tblClinic
    {
        public int ClinicId { get; set; }
        public string Name { get; set; }
        public System.DateTime DateOfConstruction { get; set; }
        public string Owner { get; set; }
        public string Address { get; set; }
        public int NumberOfFloors { get; set; }
        public int NumberOfRoomsPerFloor { get; set; }
        public bool Terrace { get; set; }
        public bool Yard { get; set; }
        public int NumberOfAccessPointsForAmbulanceCars { get; set; }
        public int NumberOfAccessPointsForInvalids { get; set; }
    }
}
