using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new TourPage());
            Manager.MainFrame = MainFrame;

            //ImportTours();
        }
        
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack) BtnBack.Visibility = Visibility.Visible;
            else BtnBack.Visibility = Visibility.Hidden;
        }

        private void ImportTours()
        {
            int id = 1;            

            var fileData = File.ReadAllLines(@"C:\Users\user\Desktop\erik i maks 2\Туры.txt");
            var images = Directory.GetFiles(@"C:\Users\user\Desktop\erik i maks 2\Фото");

            foreach (var line in fileData)
            {                
                var data = line.Split(new char[] {'\t'});

                using (StreamReader sr = new StreamReader("TourId.txt")) id = int.Parse(sr.ReadLine());
                using (StreamWriter sw = new StreamWriter("TourId.txt", false)) sw.WriteLine(id + 1);

                Tour tempTour = new Tour
                {
                    Id = id,
                    Name = data[0].Replace("\"", ""),
                    TicketCount = int.Parse(data[2]),
                    Price = decimal.Parse(data[3]),
                    IsActual = (data[4] == "0") ? false : true
                };

                foreach (var tourType in data[5].Split(new string[]{","}, StringSplitOptions.RemoveEmptyEntries))
                {
                    var currentType = ToursEntities.GetContext().Types.ToList().FirstOrDefault(p => p.Name == tourType);
                    if (currentType != null)
                    {
                        tempTour.Types.Add(currentType);
                    }
                }

                try
                {
                    tempTour.ImagePreview = File.ReadAllBytes(images.FirstOrDefault(p => p.Contains(tempTour.Name)));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                ToursEntities.GetContext().Tours.Add(tempTour);
                ToursEntities.GetContext().SaveChanges();
            }
        }
    }
}
