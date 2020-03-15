using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using ClinicManagement.DataLayer;
using ClinicManagement.ViewModel.Entities;
using ClinicManagement.DataLayer.Model.Entities;


namespace ClinicManagement.Views
{
    /// <summary>
    /// Interaction logic for UpdatePatient.xaml
    /// </summary>
    public partial class UpdateVisit : Window
    {
        private int visitId = -1;
        private ObservableCollection<Patient> patients = new ObservableCollection<Patient>();
        public UpdateVisit(VisitItem visit = null)
        {
            InitializeComponent();

            patients = DataManipulations.GetPatients();
            if (patients.Count == 0)
            {
                btOk.IsEnabled = false;
            }
            cbPatient.ItemsSource = patients;

            cbDiagnosis.ItemsSource = Diagnoses.diagnoses;

            if (visit != null)
            {
                visitId = visit.Id;

                if (Diagnoses.diagnoses.Contains(visit.Diagnosis))
                {
                    cbDiagnosis.SelectedItem = visit.Diagnosis;
                }

                var patient = patients.FirstOrDefault(x => x.Id == visit.PatientId);
                if (patient!=null)
                {
                    cbPatient.SelectedItem = patient;
                }

                cbVisit.SelectedIndex = visit.Initial ? 0 : 1;

                //tbName.Text = patient.Name;
                //tbAddress.Text = patient.Address;
                //tbPhone.Text = patient.Phone;
                //cbGender.SelectedIndex = patient.Gender == "♂" ? 0 : 1;

            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            ItemsRepository.VisitAddOrUpdate(
                new Visit()
                {
                    Id = visitId,
                    Initial = (cbVisit.SelectedIndex == 0),
                    Date = cdDate.SelectedDate ?? DateTime.Now,
                    Diagnosis = cbDiagnosis.SelectedItem.ToString(),
                    patient = (cbPatient.SelectionBoxItem as Patient)

        }
                );


            Close();
        }
    }
}
