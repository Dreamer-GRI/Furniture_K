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
            cmbContractNumber.SelectedValuePath = "idConttract";
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
            /*cmbModelPrice.SelectedValuePath = "idModel";
            cmbModelPrice.DisplayMemberPath = "ModelPrice";
            cmbModelPrice.ItemsSource = ConnectHelper.FurnitureOBJ.Model.ToList();*/
        }

         // ///////////////// //
        // Добавление данных //
       // ///////////////// //
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Проверка на пустое и нулевое значение в полях
            if (String.IsNullOrEmpty(Quantity.Text) || String.IsNullOrEmpty(cmbContractNumber.Text) || String.IsNullOrEmpty(cmbFurnitureName.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены!");
            }
            else
            {
                // Проверка на наличие данных в БД
                /*if (ConnectHelper.FurnitureOBJ.Sale.Where(u => u.idContract == Int32.Parse(cmbContractNumber.SelectedValue.ToString())).FirstOrDefault() != null)
                {
                    MessageBox.Show("Такая продажа уже есть!");
                }
                else
                {*/
                Sale sale1 = new Sale()
                {
                    Quantity = int.Parse(Quantity.Text),
                    idContract = int.Parse(cmbContractNumber.SelectedValue.ToString()),
                    idModel = int.Parse(cmbFurnitureName.SelectedValue.ToString())
                };
                ConnectHelper.FurnitureOBJ.Sale.Add(sale1); // Добавление данных в таблицу "Sale"
                ConnectHelper.FurnitureOBJ.SaveChanges();
                MessageBox.Show("Данные успешно добавлены");
                //}
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
