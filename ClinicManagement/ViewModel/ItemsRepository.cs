using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    

        public  static ObservableCollection<PatientItem> PatientsList = new ObservableCollection<PatientItem>();
        public static ObservableCollection<VisitItem> VisitsList = new ObservableCollection<VisitItem>();

    }
}
