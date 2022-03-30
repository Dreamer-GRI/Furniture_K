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
    /// Логика взаимодействия для ContractPage.xaml
    /// </summary>
    public partial class ContractPage : Page
    {
        public ContractPage()
        {
            InitializeComponent();
            dgContract.ItemsSource = ConnectHelper.FurnitureOBJ.Contract.ToList(); // Берёт данные из таблицы "Contract"
        }

         // ///////////////// //
        // Возвращене в меню //
       // ///////////////// //
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.FrameOBJ.Navigate(new Pages.MainPage());
        }

         // ////////// //
        // Фильтрация //
       // ////////// //
        private void cmbFilt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

         // ////////// //
        // Добавление //
       // ////////// //
        private void btnAddContract_Click(object sender, RoutedEventArgs e)
        {

        }
              
         // ////////////// //
        // Редактирование //
       // ////////////// //
        private void btnEditContract_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
