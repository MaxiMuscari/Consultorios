using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ConsultoriosApp
{   public enum Especialities { Dermatologia, Cardiologia, Hematologia, Nefrologia, Neurologia, Traumatologia, Oftalmologia }
    public class Medic
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DNI { get; set; }
        public string CUIL { get; set; }
        public string PhoneNumber { get; set; }
        //public virtual Especiality Especiality { get; set; }
        public Especialities Especialities { get; set; }
        public string Names { get { return $"{Name} {Surname}"; } }



        public Medic(string name, string surname, string DNI, string CUIL, string phoneNumber, Especialities especialities)
        {
            this.Name = name;
            this.Surname = surname;
            this.DNI = DNI;
            this.CUIL = CUIL;
            this.PhoneNumber = phoneNumber;
            this.Especialities = especialities;
        }
    }
    

}
