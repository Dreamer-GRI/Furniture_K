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
    /// Логика взаимодействия для SalePage.xaml
    /// </summary>
    public partial class SalePage : Page
    {
        public SalePage()
        {
            InitializeComponent();
            dgSale.ItemsSource = ConnectHelper.FurnitureOBJ.Sale.ToList(); // Берёт данные из таблицы "Sale"
            cmbFilt.SelectedValuePath = "idModel";
            cmbFilt.DisplayMemberPath = "ModelPrice";
            cmbFilt.ItemsSource = ConnectHelper.FurnitureOBJ.Model.ToList();
        }

         // ///////////////// //
        // Возвращене в меню //
       // ///////////////// //
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.FrameOBJ.Navigate(new Pages.MainPage());
        }

         // ////////// //
        // Добавление //
       // ////////// //
        private void btnAddSale_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.FrameOBJ.Navigate(new SaleAddPage());
        }

         // ////////////// //
        // Редактирование //
       // ////////////// //
        private void btnEditSale_Click(object sender, RoutedEventArgs e)
        {
            Sale sale = dgSale.SelectedItem as Sale;
            if (sale == null)
            {
                MessageBox.Show("Продажа не выбрана");
            }
            else
            {
                FrameApp.FrameOBJ.Navigate(new SaleEditPage(sale));
            }
        }

         // ////////// //
        // Фильтрация //
       // ////////// //
        private void cmbFilt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SaleID = (int)cmbFilt.SelectedValue;
            dgSale.ItemsSource = ConnectHelper.FurnitureOBJ.Sale.Where(x => x.idModel == SaleID).ToList();
        }
    }
}
