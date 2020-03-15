using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagement.DataLayer.Model.Entities;

namespace ClinicManagement.ViewModel.Entities
{
   public class VisitItem
    {

        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Date { get; set; }
        public bool Initial { get; set; }
        public string Diagnosis { get; set; }
        public string Name { get; set; }

        public static void UpdateList(DbSet<Visit> dbVisits)
        {
            throw new NotImplementedException();
        }
    }
}
