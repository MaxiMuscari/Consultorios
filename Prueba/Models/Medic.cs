using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Prueba
{   public enum Especialities { Cirujano, Enfermero}
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

        public Medic() { }


        public Medic(string name, string surname, string dni, string cuil, string phoneNumber, Especialities especialities)
        {
            this.Name = name;
            this.Surname = surname;
            this.DNI = dni;
            this.CUIL = cuil;
            this.PhoneNumber = phoneNumber;
            this.Especialities = especialities;
        }
    }
    

}
