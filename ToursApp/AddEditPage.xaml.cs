using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.IO;

namespace ToursApp
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {

        public int HotelId { get; set; } = 3;

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
                using (StreamReader sr = new StreamReader("HotelId.txt")) HotelId = int.Parse(sr.ReadLine());
                using (StreamWriter sw = new StreamWriter("HotelId.txt", false)) sw.Write(HotelId + 1);
                _currentHotel.Id = HotelId;
                ToursEntities.GetContext().Hotels.Add(_currentHotel);
            }

                

            try
            {
                ToursEntities.GetContext().SaveChanges();
                MessageBox.Show("информация сохранена");

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
