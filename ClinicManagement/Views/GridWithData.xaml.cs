using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClinicManagement.ViewModel.Entities;

namespace ClinicManagement.Views
{
    /// <summary>
    /// Interaction logic for GridWithData.xaml
    /// </summary>
    public partial class GridWithData : UserControl
    {
        private static ListItemsVariants variant;

        public GridWithData(ListItemsVariants itemVariant)
        {
            variant = itemVariant;
            InitializeComponent();
            FillTheListView();
            
        }

        private void FillTheListView()
        {
            switch (variant)
            {
                case ListItemsVariants.patients:
            ListWithData.ItemsSource = ItemsRepository.PatientsList;
                    break;
                case ListItemsVariants.visits:
                    ListWithData.ItemsSource = ItemsRepository.VisitsList;
                    break;
            }
        }

        public void DeletePatient()
        {
            var patient = ListWithData.SelectedItem;
            if (patient != null)
            {
                ItemsRepository.DeletePatient(patient as PatientItem);
            }
        }

        public void DeleteVisit()
        {
            var visit = ListWithData.SelectedItem;
            if (visit != null)
            {
                ItemsRepository.DeleteVisit(visit as VisitItem);
            }
        }

        public void AddPatient()
        {
            UpdatePatient patientEdit = new UpdatePatient();
            patientEdit.ShowDialog();
        }

        public void UpdatePatient()
        {

            var patient = ListWithData.SelectedItem;
            if (patient != null)
            {
                UpdatePatient patientEdit = new UpdatePatient(patient as PatientItem);
                patientEdit.ShowDialog();
            }
        }

        public void AddVisit()
        {
            UpdateVisit updateVisit = new UpdateVisit();
            updateVisit.ShowDialog();
        }

        public void UpdateVisit()
        {

            var visit = ListWithData.SelectedItem;
            if (visit != null)
            {
                UpdateVisit updateVisit = new UpdateVisit(visit as VisitItem);
                updateVisit.ShowDialog();
            }
        }
    }
}
