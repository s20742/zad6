using System;
using System.Collections.Generic;

namespace HospitalWebApi.Entity
{
    public class Patient
    {
        public int IdPatient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        
        public virtual ICollection<Prescription> Prescriptions { get; set; }

        public Patient()
        {
            Prescriptions = new HashSet<Prescription>();
        }
    }
}