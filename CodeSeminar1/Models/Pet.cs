using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSeminar1.Models
{
    internal class Pet : IComparable<Pet>
    {
        private int id;
        public int Id { get { return id; } }

        private string name;
        public string Name { get { return name; } }

        private Veterinarian vet;
        public Veterinarian Vet { get { return vet; } }

        private Clinic admittedClinic;
        public Clinic AdmittedClinic { get { return admittedClinic; } }

        public Pet(int id, string name, Veterinarian vet, Clinic clinic)
        {
            this.id = id;
            this.name = name;
            this.vet = vet;
            this.admittedClinic = clinic;
        }

        public override string ToString()
        {
            return (this.id + "id" + this.name + "name" + this.vet.Name + " namnet på vet" + this.admittedClinic.Name + "name of clinic");
        }

        public int CompareTo(Pet other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}
