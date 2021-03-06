﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ClinicManagement.DataLayer;
using ClinicManagement.DataLayer.Model;
using ClinicManagement.DataLayer.Model.Entities;
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
        //Two observable collections that feeds corresponding grids
        public static ObservableCollection<PatientItem> PatientsList = new ObservableCollection<PatientItem>();
        public static ObservableCollection<VisitItem> VisitsList = new ObservableCollection<VisitItem>();

        public static void UpdateLists()
        {
            UpdatePatients();
            UpdateVisits();
        }

        /// <summary>
        /// Converts Patient model objects to Patient view objects
        /// </summary>
        public static void UpdatePatients()
        {
            var patientsData = DataManipulations.GetPatients();
                PatientsList.Clear();
            if (patientsData.Count > 0)
            {
                foreach (var patient in patientsData)
                {
                    PatientsList.Add(new PatientItem()
                    {
                        Address = patient.Address,
                        DateOfBirth = patient.DateOfBirth.ToString("dd/MM/yyyy"),
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

        /// <summary>
        /// Converts Visit model objects to Visit view objects
        /// </summary>
        public static void UpdateVisits()
        {
            var visitsData = DataManipulations.GetVisits();
                VisitsList.Clear();
            if (visitsData.Count > 0)
            {
                foreach (var visit in visitsData)
                {
                    VisitsList.Add(new VisitItem()
                        {
                            Id = visit.Id,
                            PatientId = visit.patient.Id,
                            Date = visit.Date.ToString("dd/MM/yyyy"),
                            Diagnosis = visit.Diagnosis,
                            Initial = visit.Initial,
                            Name = visit.patient.Name
                    }
                    );
                }
            }
        }

        public static void DeletePatient(PatientItem patient)
        {
            if (DataManipulations.DeletePatient(patient.Id))
            {
             UpdateLists();
            }
        }

        public static void DeleteVisit(VisitItem visitItem)
        {
            if (DataManipulations.DeleteVisit(visitItem.Id))
            {
               UpdateLists();
            }
        }


        public static void PatientAddOrUpdate(Patient patient)
        {
            if (DataManipulations.PatientAddOrUpdate(patient))
            {
                UpdateLists();
            }
        }

        public static void VisitAddOrUpdate(Visit visit)
        {
            if (DataManipulations.VisitAddOrUpdate(visit))
            {
                UpdateLists();
            }
        }
    }
}
