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
using System.Windows.Shapes;
using ClinicManagement.ViewModel.Entities;
using ClinicManagement.DataLayer.Model.Entities;


namespace ClinicManagement.Views
{
    /// <summary>
    /// Interaction logic for UpdatePatient.xaml
    /// </summary>
    public partial class UpdatePatient : Window
    {
        private int patientId = -1;
        public UpdatePatient(PatientItem patient = null)
        {
            InitializeComponent();
            if (patient != null)
            {
                patientId = patient.Id;
                tbName.Text = patient.Name;
                tbAddress.Text = patient.Address;
                tbPhone.Text = patient.Phone;
                cbGender.SelectedIndex = patient.Gender == "♂" ? 0 : 1;

            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

            ItemsRepository.PatientAddOrUpdate(
                new Patient()
                {
                    Id = patientId,
                    Address = tbAddress.Text,
                    Phone = tbPhone.Text,
                    DateOfBirth = cdDateBirth.SelectedDate?? DateTime.Now,
                    MaleGender = (cbGender.SelectedIndex == 0),
                    Name = tbName.Text
                }
                );


            Close();
        }
    }
}
