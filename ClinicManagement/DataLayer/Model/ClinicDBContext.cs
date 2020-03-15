using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagement.DataLayer.Model.Entities;

namespace ClinicManagement.DataLayer.Model
{
    class Clinic : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visit> Visits{ get; set; }

        /// <summary>
        /// Connection which used to initialization
        /// </summary>
        public static string currentConnection = string.Empty;
        /// <summary>
        /// Is db initialized and ready to work with
        /// </summary>
        public static bool IsConnected = false;

        public Clinic(string connString)
        {
            
            Database.Connection.ConnectionString = connString;
            //Drops and Create new DB with basic scheme
            Database.SetInitializer(new DropCreateDatabaseAlways<Clinic>());
        }

        /// <summary>
        /// Populates DB with test data
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
       public static Exception CreateDb(string conn)
        {
            try
            {
                using (Clinic db = new Clinic(conn))
                {
                    db.Database.Initialize(true);
                }

                using (Clinic db = new Clinic(conn))
                {
                    var p1 = new Patient()
                    {
                        Address = "Los Angeles",
                        DateOfBirth = DateTime.Now,
                        MaleGender = true,
                        Name = "John Connor",
                        Phone = "+05423"
                    };

                    var p2 = new Patient()
                    {
                        Address = "Russia",
                        DateOfBirth = DateTime.Now,
                        MaleGender = false,
                        Name = "Joahnna",
                        Phone = "+7777777"
                    };

                    var p3 = new Patient()
                    {
                        Address = "Malaysia",
                        DateOfBirth = DateTime.Now,
                        MaleGender = true,
                        Name = "Vernon"
                    
                    };

                    var v1 = new Visit()
                    {
                        Date = DateTime.Now,
                        Diagnosis = Diagnoses.diagnoses[0],
                        patient = p1,
                        Initial = true
                    };

                    var v2 = new Visit()
                    {
                        Date = DateTime.Now,
                        Diagnosis = Diagnoses.diagnoses[0],
                        patient = p1,
                        Initial = false
                    };

                    var v3 = new Visit()
                    {
                        Date = DateTime.Now,
                        Diagnosis = Diagnoses.diagnoses[1],
                        patient = p2,
                        Initial = true
                    };

                    db.Patients.AddRange(new List<Patient>(){ p1, p2, p3 });
                    db.Visits.AddRange(new List<Visit>(){ v1, v2, v3 });

                    db.SaveChanges();
                }

                currentConnection = conn;
                IsConnected = true;

                return null;
            }
            catch (Exception e)
            {
                var a = e.Message;
                return e;
            }

            
        }

        
    }
}
