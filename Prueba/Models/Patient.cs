using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Prueba
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DNI { get; set; }
        public string Address { get; set; }
        public string MedicalSecurity { get; set; }
        public string PhoneNumber { get; set; }


        public Patient(string Name, string Surname, string DNI, string Address, string MedicalSecurity, string PhoneNumber)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.DNI = DNI;
            this.Address = Address;
            this.MedicalSecurity = MedicalSecurity;
            this.PhoneNumber = PhoneNumber;
        }

    }
}
