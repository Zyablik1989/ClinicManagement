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
using ClinicManagement.Views;

namespace ClinicManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GridContainerPatients.Children.Add(new GridWithData(ListItemsVariants.patients));
            GridContainerVisits.Children.Add(new GridWithData(ListItemsVariants.visits));
        } 

        private void PatientAdd(object sender, RoutedEventArgs e)
        {
           ItemsRepository.PatientsList.Add(new Patient()
            {
                Address = "Los Angeles",
                DateOfBirth = DateTime.Now.ToString("U"),
                Gender = "♂",
                Id = 1,
                Name = "John Connor",
                Phone = "05423"
            });
        }

        private void PatientEdit(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void PatientDelete(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void VisitAdd(object sender, RoutedEventArgs e)
        {
                ItemsRepository.VisitsList.Add(new Visit()
                {
                    Id = 1,
                    Date = DateTime.Now.ToString("U"),
                    Diagnosis = "Plantar Fasciosis",
                    ClientId = 1,
                    Initial = true,
                    Name = "John"

                }

                );
        }

        private void VisitEdit(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void VisitDelete(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            btConnect.IsEnabled = false;
            string conn = tbConnectionString.Text;

            var result = DataLayer.Model.Clinic.CreateDb(conn);
            if (result != null)
            {
               if( (result as Exception).Message.Contains("in use"))
                {
                    System.Windows.MessageBox.Show(
                        "This base is already in use"
                        ,
                        "Error"
                        , MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
                if ((result as Exception).Message.Contains("error: 26"))
                {
                    System.Windows.MessageBox.Show(
                        "Cannot find this Server"
                        ,
                        "Error"
                        , MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }

                tbConnectionStatus.Text = "An error occured";
                btConnect.IsEnabled = true;
            }

            tbConnectionStatus.Text = "Connected";

            btPatientAdd.IsEnabled = true;
            btPatientEdit.IsEnabled = true;
            btPatientDelete.IsEnabled = true;

            btVisitAdd.IsEnabled = true;
            btVisitEdit.IsEnabled = true;
            btVisitDelete.IsEnabled = true;
        }
    }
}
