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
            ListWithData.ItemsSource = DataLayer.ItemsRepository.PatientsList;
                    break;
                case ListItemsVariants.visits:
                    ListWithData.ItemsSource = DataLayer.ItemsRepository.VisitsList;
                    break;

            }
            {
                    
            }

        }
    }
}
