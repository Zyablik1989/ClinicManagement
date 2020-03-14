using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClinicManagement.DataLayer.Model.Entities
{
   public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public bool MaleGender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public virtual List<Visit> visits { get; set; }

        public Patient()
        {
            this.visits = new List<Visit>();
        }
    }
}
