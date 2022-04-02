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
    /// Логика взаимодействия для SaleAddPage.xaml
    /// </summary>
    public partial class SaleAddPage : Page
    {
        public SaleAddPage()
        {
            InitializeComponent();
             // ////////////// //
            // Номер договора //
           // ////////////// //
            cmbContractNumber.SelectedValuePath = "idContract";
            cmbContractNumber.DisplayMemberPath = "ContractNumber";
            cmbContractNumber.ItemsSource = ConnectHelper.FurnitureOBJ.Contract.ToList();

             // /////////////// //
            // Название мебели //
           // /////////////// //
            cmbFurnitureName.SelectedValuePath = "idModel";
            cmbFurnitureName.DisplayMemberPath = "FurnitureName";
            cmbFurnitureName.ItemsSource = ConnectHelper.FurnitureOBJ.Model.ToList();

             // /////////// //
            // Цена модели //
           // /////////// //
            cmbModelPrice.SelectedValuePath = "idModel";
            cmbModelPrice.DisplayMemberPath = "ModelPrice";
            cmbModelPrice.ItemsSource = ConnectHelper.FurnitureOBJ.Model.ToList();
        }

         // ///////////////// //
        // Добавление данных //
       // ///////////////// //
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

         // /////////////////////////// //
        // Возвращене в таблицу "Sale" //
       // /////////////////////////// //
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
