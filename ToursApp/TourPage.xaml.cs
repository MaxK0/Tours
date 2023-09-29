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

namespace ToursApp
{
    /// <summary>
    /// Логика взаимодействия для TourPage.xaml
    /// </summary>
    public partial class TourPage : Page
    {
        public TourPage()
        {
            InitializeComponent();

            var allTypes = ToursEntities.GetContext().Types.ToList();
            allTypes.Insert(0, new Type
            {
                Name = "Все типы"

            });
            ComboType.ItemsSource = allTypes;

            CheckActual.IsChecked = true;
            ComboType.SelectedIndex = 0;
                
            var currentTours= ToursEntities.GetContext().Tours.ToList();
            LViewTours.ItemsSource = currentTours;

        }
        
        private void UpdateTours()
        {
            var currentTours =ToursEntities.GetContext().Tours.ToList();
            if (ComboType.SelectedIndex > 0)
                currentTours = currentTours.Where(p=> p.Types.Contains(ComboType.SelectedItem as Type)).ToList();  

            currentTours= currentTours.Where(p=> p.Name.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            if (CheckActual.IsChecked.Value)
                currentTours=currentTours.Where(p=> p.IsActual).ToList();   
            LViewTours.ItemsSource = currentTours.OrderBy(p=>p.TicketCount).ToList();
           
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CheckActual_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
