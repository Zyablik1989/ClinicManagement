using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ClinicManagement.DataLayer;
using ClinicManagement.DataLayer.Model;
using ClinicManagement.ViewModel.Entities;

namespace ClinicManagement.ViewModel.Entities
{
    public enum ListItemsVariants
    {
        patients,
        visits
    }


    public class ItemsRepository
    {

        public static void UpdateLists()
        {
            UpdatePatients();
            UpdateVisits();
        }

        public static void UpdatePatients()
        {

            var patientsData = DataManipulations.GetPatients();
            if (patientsData.Count > 0)
            {
                PatientsList.Clear();
                foreach (var patient in patientsData)
                {
                    PatientsList.Add(new PatientItem()
                    {
                        Address = patient.Address,
                        DateOfBirth = patient.DateOfBirth.ToString("MM/dd/yyyy"),
                        Gender = 
                            patient.MaleGender
                                ? "♂"
                                : "♀",
                        Id = patient.Id,
                        Name = patient.Name,
                        Phone = patient.Phone

                    });
                }
            }
        }

        public static void UpdateVisits()
        {
            var visitsData = DataManipulations.GetVisits();
            if (visitsData.Count > 0)
            {
                VisitsList.Clear();
                foreach (var visit in visitsData)
                {
                    VisitsList.Add(new VisitItem()
                        {
                            Id = visit.Id,
                            ClientId = visit.patient.Id,
                            Date = visit.Date.ToString("MM/dd/yyyy"),
                            Diagnosis = visit.Diagnosis,
                            Initial = visit.Initial,
                            Name = visit.patient.Name

                    }

                    );
                }
            }
        }

  

        public static ObservableCollection<PatientItem> PatientsList = new ObservableCollection<PatientItem>();
        public static ObservableCollection<VisitItem> VisitsList = new ObservableCollection<VisitItem>();

    }
}
