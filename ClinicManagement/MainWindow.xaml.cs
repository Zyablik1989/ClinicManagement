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
using ClinicManagement.DataLayer;
using ClinicManagement.Views;
using ClinicTest.Model.Entities;

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
            DataLayer.ItemsRepository.PatientsList.Add(new Patient()
            {
                Address = "Los Angeles",
                DateOfBirth = DateTime.Now.ToString("U"),
                Sex = "♂",
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
                DataLayer.ItemsRepository.VisitsList.Add(new Visit()
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
            throw new NotImplementedException();
        }
    }
}
