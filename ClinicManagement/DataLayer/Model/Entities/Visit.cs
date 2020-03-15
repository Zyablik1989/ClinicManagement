using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagement.DataLayer.Model.Entities
{
   public class Visit
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool Initial { get; set; }
        [Required]
        public string Diagnosis { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual Patient patient { get; set; }
    }
}
