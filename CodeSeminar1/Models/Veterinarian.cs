using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSeminar1.Models
{
    internal class Veterinarian : Employee
    {
        private int id;
        public int Id { get { return id; } }

        private string name;
        public string Name { get { return name; } }

        private List<Pet> treatedPets;
        public List<Pet> TreatedPets { get { return treatedPets; } }

        public Veterinarian(int id, string name, double salary) : base(salary)
        {
            this.id = id;
            this.name = name;
            treatedPets = new List<Pet>();
        }

        public void AddTreatedPet(Pet pet)
        {
            treatedPets.Add(pet);
        }

        public void RemoveTreatedpet(Pet pet)
        {
            treatedPets.Remove(pet);
        }

        public bool TreatsPet(string name)
        {
            return treatedPets.Where(x => x.Name == name).Any();
        }



        public override string ToString()
        {
            return ("id" + this.id + " nameet " + this.Name  );
        }
    }
}
