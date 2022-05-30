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
    /// Логика взаимодействия для AllDataPage.xaml
    /// </summary>
    public partial class AllDataPage : Page
    {
        public AllDataPage()
        {
            InitializeComponent();
            dgAllData.ItemsSource = ConnectHelper.FurnitureOBJ.Keys.ToList(); // Берёт данные из таблицы "Keys"

            cmbFilt.SelectedValuePath = "idBuyer";
            cmbFilt.DisplayMemberPath = "NameBuyer";
            cmbFilt.ItemsSource = ConnectHelper.FurnitureOBJ.Buyer.ToList(); // Берёт данные из таблицы "Buyer"
        }

         // ////////// //
        // Фильтрация //
       // ////////// //
        private void cmbFilt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int BuyerID = (int)cmbFilt.SelectedValue;
            dgAllData.ItemsSource = ConnectHelper.FurnitureOBJ.Keys.Where(x => x.idBuyer == BuyerID).ToList();
        }

         // ///////////////// //
        // Возвращене в меню //
       // ///////////////// //
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.FrameOBJ.Navigate(new Pages.MainPage());
        }

        private void dgBuyer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {

        }
    }
}
