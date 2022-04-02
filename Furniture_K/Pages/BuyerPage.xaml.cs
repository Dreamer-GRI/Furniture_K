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
    /// Логика взаимодействия для BuyerPage.xaml
    /// </summary>
    public partial class BuyerPage : Page
    {
        public BuyerPage()
        {
            InitializeComponent();
            dgBuyer.ItemsSource = ConnectHelper.FurnitureOBJ.Buyer.ToList(); // Берёт данные из таблицы "Buyer"
            cmbFilt.SelectedValuePath = "idBuyer";
            cmbFilt.DisplayMemberPath = "Address";
            cmbFilt.ItemsSource = ConnectHelper.FurnitureOBJ.Buyer.ToList();
        }

         // ////////// //
        // Фильтрация //
       // ////////// //
        private void cmbFilt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int BuyerID = (int)cmbFilt.SelectedValue;
            dgBuyer.ItemsSource = ConnectHelper.FurnitureOBJ.Buyer.Where(x => x.idBuyer == BuyerID).ToList();
        }

         // ///////////////// //
        // Возвращене в меню //
       // ///////////////// //
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.FrameOBJ.Navigate(new Pages.MainPage());
        }

         // ///////////////// //
        // Добавление данных //
       // ///////////////// //
        private void btnAddBuyer_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.FrameOBJ.Navigate(new BuyerAddPage());
        }
                 
         // ///////////////////// //
        // Редактирование данных //
       // ///////////////////// //
        private void btnEditBuyer_Click(object sender, RoutedEventArgs e)
        {
            Buyer buyer = dgBuyer.SelectedItem as Buyer;
            if(buyer == null)
            {
                MessageBox.Show("Покупатель не выбран");
            }
            else
            {
                FrameApp.FrameOBJ.Navigate(new BuyerEditPage(buyer)); 
            }
        }
    }
}
