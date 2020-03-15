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

        public static bool DeletePatient(int patientId)
        {
            if (Clinic.IsConnected)
            {
                using (Clinic db = new Clinic(Clinic.currentConnection))
                {
                    try
                    {
                        db.Patients.Load();
                        var patient = db.Patients.FirstOrDefault(x => x.Id == patientId);
                        if (patient!=null)
                        {
                            db.Patients.Remove(patient);
                            db.SaveChanges();
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public static bool DeleteVisit(int visitItemId)
        {
            if (Clinic.IsConnected)
            {
                using (Clinic db = new Clinic(Clinic.currentConnection))
                {
                    try
                    {
                        db.Patients.Load();
                        db.Visits.Load();
                        var visit = db.Visits.FirstOrDefault(x => x.Id == visitItemId);
                        if (visit != null)
                        {
                            db.Visits.Remove(visit);
                            db.SaveChanges();
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public static bool PatientAddOrUpdate(Patient patient)
        {
            if (Clinic.IsConnected)
            {
                using (Clinic db = new Clinic(Clinic.currentConnection))
                {
                    try
                    {
                        db.Patients.Load();
                        if (patient.Id == -1)
                        {
                            
                            db.Patients.Add(patient);
                            db.SaveChanges();
                        }
                        else
                        {
                            var p = db.Patients.FirstOrDefault(x => x.Id == patient.Id);
                            if (p != null)
                            {
                                db.Entry(p).CurrentValues.SetValues(patient);
                                db.SaveChanges();
                            }
                            else
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        public static bool VisitAddOrUpdate(Visit visit)
        {
            if (Clinic.IsConnected)
            {
                using (Clinic db = new Clinic(Clinic.currentConnection))
                {
                    try
                    {
                        db.Patients.Load();
                        db.Visits.Load();
                        if (visit.Id == -1 && visit.patient != null)
                        {
                            var p = db.Patients.FirstOrDefault(x => x.Id == visit.patient.Id);
                            visit.patient = p;

                            db.Visits.Add(visit);
                            db.SaveChanges();
                        }
                        else
                        {
                            var v = db.Visits.FirstOrDefault(x => x.Id == visit.Id);
                            if (v != null && visit.patient!=null)
                            {
                            var p = db.Patients.FirstOrDefault(x => x.Id == visit.patient.Id);
                                v.patient = p;
                                db.Entry(v).CurrentValues.SetValues(visit);
                                db.SaveChanges();
                            }
                            else
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }
    }
}
