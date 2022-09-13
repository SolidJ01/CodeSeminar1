using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSeminar1.Models
{
    internal class Hospital 
    {
        private string name;
        public string Name { get { return name; } }

        private List<Clinic> clinics;
        public List<Clinic> Clinics { get { return clinics; } }

        private List<Veterinarian> veterinarians;
        public List<Veterinarian> Veterinarians {  get { return veterinarians; } }

        private List<Pet> petsInHospital;
        public List<Pet> PetsInHospital { get { return petsInHospital; } }

        public delegate void PetAdmissionDelegate(Pet pet);
        private PetAdmissionDelegate petAdmission;

        public Hospital(string name)
        {
            this.name = name;
            clinics = new List<Clinic>();
            veterinarians = new List<Veterinarian>();
            petAdmission = new PetAdmissionDelegate(Admitpet);
        }

        public void AddClinic(Clinic newClinic)
        {
            clinics.Add(newClinic);
        }

        public void AddClinic(int id, string name)
        { 
            clinics.Add(new Clinic(id, name, petAdmission));
        }

        public void Admitpet(Pet pet)
        {
            petsInHospital.Add(pet);
        }

        public void DischargePet(string petname, string clinicname)
        {
            try
            {
                Clinic clinic = clinics.Where(x => x.Name == clinicname).First();
                Pet pet = petsInHospital.Where(x => x.Name == petname).First();
                petsInHospital.Remove(pet);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void CreateVeterinarianAndAddToClinic(Veterinarian vet, int clinicId)
        {
            veterinarians.Add(vet);
            try
            {
                clinics.ElementAt(clinicId).AddVeterinarian(vet); 
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void PrintPetsDetails()
        {
            Console.WriteLine("All pets in hospital " + this.Name + ": ");
            foreach (Pet pet in PetsInHospital)
            {
                Console.WriteLine("[PET] name: " + pet.Name + " | veterinarian: " + pet.Vet.Name + " | clinic: " + pet.AdmittedClinic.Name);
            }
        }

        public void PrintVeterinariansPetsDetails(string vetName)
        {
            try
            {
                Veterinarian vet = veterinarians.Where(x => x.Name == vetName).First();
                Console.WriteLine("Veterinarian " + vet.Name + " treats the following pets: ");
                foreach (Pet pet in vet.TreatedPets)
                {
                    Console.WriteLine(pet.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Thats the wrong name" + e.Message);
            }
        }

        public void PrintPetsVet(string petname)
        {
            try
            {
                Veterinarian vet = veterinarians.Where(x => x.TreatsPet(petname)).First();
                Console.WriteLine("Pet " + petname + " is treated by veterinarian " + vet.Name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
