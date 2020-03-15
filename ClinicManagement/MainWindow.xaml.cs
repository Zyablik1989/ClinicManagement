using System;
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
        private static GridWithData PatientsGrid = new GridWithData(ListItemsVariants.patients);
        private static GridWithData VisitsGrid = new GridWithData(ListItemsVariants.visits);
        public MainWindow()
        {
            InitializeComponent();
            GridContainerPatients.Children.Add(PatientsGrid);
            GridContainerVisits.Children.Add(VisitsGrid);
        } 

        private void PatientAdd(object sender, RoutedEventArgs e)
        {
            PatientsGrid.AddPatient();
        }

        private void PatientEdit(object sender, RoutedEventArgs e)
        {
            PatientsGrid.UpdatePatient();
        }

        private void PatientDelete(object sender, RoutedEventArgs e)
        {
            PatientsGrid.DeletePatient();
        }

        private void VisitAdd(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void VisitEdit(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void VisitDelete(object sender, RoutedEventArgs e)
        {
            VisitsGrid.DeleteVisit();
        }

        private void Connect(object sender, RoutedEventArgs e)
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

            ItemsRepository.UpdateLists();

            btPatientAdd.IsEnabled = true;
            btPatientEdit.IsEnabled = true;
            btPatientDelete.IsEnabled = true;

            btVisitAdd.IsEnabled = true;
            btVisitEdit.IsEnabled = true;
            btVisitDelete.IsEnabled = true;
        }

    }
}
