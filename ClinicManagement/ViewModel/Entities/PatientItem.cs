using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagement.DataLayer.Model.Entities;

namespace ClinicManagement.ViewModel.Entities
{
   public class PatientItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }



        
    }
}
