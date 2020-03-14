using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTest.Model.Entities
{
   public class Visit
    {
       public enum Diagnoses
        {
            plantarFasciosis
            , pyelonephritis
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Date { get; set; }
        public bool Initial { get; set; }
        public string Diagnosis { get; set; }
        public string Name { get; set; }
    }
}
