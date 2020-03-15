using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagement.DataLayer.Model;
using ClinicManagement.DataLayer.Model.Entities;


namespace ClinicManagement.DataLayer
{
    public class DataManipulations
    {


        public static  ObservableCollection<Patient> GetPatients()
        {
            if (Clinic.IsConnected)
            {
                using (Clinic db = new Clinic(Clinic.currentConnection))
                {
                    db.Patients.Load();
                    return db.Patients.Local;
                }
            }
            return new ObservableCollection<Patient>();
        }

        public static ObservableCollection<Visit> GetVisits()
        {
            if (Clinic.IsConnected)
            {
                using (Clinic db = new Clinic(Clinic.currentConnection))
                {
                    db.Patients.Load();
                    db.Visits.Load();
                    return db.Visits.Local;
                }
            }
            return new ObservableCollection<Visit>();
        }
    }
}
