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
using Furniture_K.Classes;

namespace Furniture_K.Pages
{
    /// <summary>
    /// Логика взаимодействия для BuyerAddPage.xaml
    /// </summary>
    public partial class BuyerAddPage : Page
    {
        public BuyerAddPage()
        {
            InitializeComponent();
        }

         // //////////////////////////// //
        // Возвращене в таблицу "Buyer" //
       // //////////////////////////// //
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.FrameOBJ.Navigate(new Pages.BuyerPage());
        }

         // ///////////////// //
        // Добавление данных //
       // ///////////////// //
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Проверка на пустое и нулевое значение в полях
            if (String.IsNullOrEmpty(FIO.Text) || String.IsNullOrEmpty(Address.Text) || String.IsNullOrEmpty(Phone.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены!");
            }
            else
            {
                // Проверка на наличие данных в БД
                if (ConnectHelper.FurnitureOBJ.Buyer.Where(u => u.NameBuyer == FIO.Text && u.Address == Address.Text && u.Phone == Phone.Text || u.Phone == Phone.Text).FirstOrDefault()!=null)
                {
                    MessageBox.Show("Такой покупатель уже есть!");
                }
                else
                {
                    Buyer buyer = new Buyer()
                    {
                        NameBuyer = FIO.Text,
                        Address = Address.Text,
                        Phone = Phone.Text
                    };
                    ConnectHelper.FurnitureOBJ.Buyer.Add(buyer); // Добавление данных в таблицу "Buyer"
                    ConnectHelper.FurnitureOBJ.SaveChanges();
                    MessageBox.Show("Данные успешно добавлены");
                }
            }
        }
    }
}
