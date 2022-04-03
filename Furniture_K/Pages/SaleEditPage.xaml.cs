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
    /// Логика взаимодействия для SaleEditPage.xaml
    /// </summary>
    public partial class SaleEditPage : Page
    {
        private Sale sl = new Sale();
        public SaleEditPage(Sale sale)
        {
            InitializeComponent();
             // ////////////// //
            // Номер договора //
           // ////////////// //
            cmbContractNumber.SelectedValuePath = "idConttract";
            cmbContractNumber.DisplayMemberPath = "ContractNumber";
            cmbContractNumber.ItemsSource = ConnectHelper.FurnitureOBJ.Contract.ToList();

             // /////////////// //
            // Название мебели //
           // /////////////// //
            cmbFurnitureName.SelectedValuePath = "idModel";
            cmbFurnitureName.DisplayMemberPath = "FurnitureName";
            cmbFurnitureName.ItemsSource = ConnectHelper.FurnitureOBJ.Model.ToList();

            sl = sale;

            Quantity.Text = sl.Quantity.ToString();
            cmbContractNumber.Text = sl.Contract.ContractNumber.ToString();
            cmbFurnitureName.Text = sl.Model.FurnitureName;
        }

         // ///////////////////// //
        // Редактирование данных //
       // ///////////////////// //
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            sl.Quantity = int.Parse(Quantity.Text);
            sl.idContract = int.Parse(cmbContractNumber.SelectedValue.ToString());
            sl.idModel = int.Parse(cmbFurnitureName.SelectedValue.ToString());

            if (sl.idModel == 0)
            {
                ConnectHelper.FurnitureOBJ.Sale.Add(sl);
            }

            try
            {
                ConnectHelper.FurnitureOBJ.SaveChanges();
                MessageBox.Show("Данные успешно изменены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

         // /////////////////////////// //
        // Возвращене в таблицу "Sale" //
       // /////////////////////////// //
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.FrameOBJ.Navigate(new Pages.SalePage());
        }
    }
}
