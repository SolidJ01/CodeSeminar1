using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSeminar1.Models
{
    internal class Clinic 
    {
        public int Id { get; set; }
        private string name;
        public string Name { get { return name; } }
        private List<Pet> petsInClinic;
        public List<Pet> PetsInClinic { get { return petsInClinic; } }

        private List<Veterinarian> veterinarians;
        public List<Veterinarian> Veterinarians { get { return veterinarians; } }

        //private delegate string petsToString();
        //private petsToString petsDelegate;

        private Hospital.PetAdmissionDelegate petAdmission;

        public Clinic(int id, string name, Hospital.PetAdmissionDelegate petAdmission)
        {
            Id = id;
            this.name = name;
            this.petsInClinic = new List<Pet>();
            this.petAdmission = petAdmission;
        }

        public void AddVeterinarian(Veterinarian vet)
        {
            veterinarians.Add(vet);
        }

        public void AdmitPet(int id, string name)
        {
            Random rand = new Random();
            int vetid = rand.Next(veterinarians.Count());
            Veterinarian vet = veterinarians.ElementAt(vetid);
            Pet pet = new Pet(Id, name, vet, this);
            petsInClinic.Add(pet);
            petAdmission(pet);

            veterinarians.ElementAt(id).AddTreatedPet(pet);
        }

        public void DischargePet(Pet pet)
        {
            petsInClinic.Remove(pet);
            Veterinarian vet = veterinarians.Where(x => x.TreatsPet(pet.Name) == true).First();
            vet.RemoveTreatedpet(pet);
        }



        public override string ToString()
        {
            return ("id" + this.Id + " name " + this.Name + "List of pets: " + this.petsInClinic);
        }

    }
}
