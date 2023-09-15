using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ToursApp
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Hotel _currentHotel = new Hotel();
        public AddEditPage(Hotel selectedHotel)
        {
            InitializeComponent();
            if (selectedHotel != null)
                _currentHotel = selectedHotel;
            DataContext = _currentHotel;
            ComboCountries.ItemsSource = ToursEntities.GetContext().Countries.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentHotel.Name))
                errors.AppendLine("Укажите название отеля");
            if (_currentHotel.CountOfStars < 1 || _currentHotel.CountOfStars > 5)
                errors.AppendLine("Количество звезд - число от 1 до 5");
            if (_currentHotel.Country == null)
                errors.AppendLine("Выберите страну");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentHotel.Id == 0)
            {
                ToursEntities.GetContext().Hotels.Add(new Hotel
                {
                    Name = NameHotel.Text,
                    CountOfStars = Convert.ToInt32(CountStars.Text),
                    Country = ComboCountries.SelectedItem as Country
                });
                ToursEntities.GetContext().SaveChanges();
            }
            //if (_currenthotel.id == 0)
            //    toursentities.getcontext().hotels.add(_currenthotel);

            //try
            //{
            //    toursentities.getcontext().savechanges();
            //    messagebox.show("информация сохранена");

            //}

            //catch (exception ex)
            //{
            //    messagebox.show(ex.message.tostring());
            //}

        }
    }
}
