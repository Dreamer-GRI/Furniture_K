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
    /// Логика взаимодействия для ModelAddPage.xaml
    /// </summary>
    public partial class ModelAddPage : Page
    {
        public ModelAddPage()
        {
            InitializeComponent();
            cmbSpecificationsModel.SelectedValuePath = "idSpecificationsModel";
            cmbSpecificationsModel.DisplayMemberPath = "SpecificationsModel1";
            cmbSpecificationsModel.ItemsSource = ConnectHelper.FurnitureOBJ.SpecificationsModel.ToList();
        }

         // //////////////////////////// //
        // Возвращене в таблицу "Model" //
       // //////////////////////////// //
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.FrameOBJ.Navigate(new Pages.ModelPage());
        }

         // ///////////////// //
        // Добавление данных //
       // ///////////////// //
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Проверка на пустое и нулевое значение в полях
            if (String.IsNullOrEmpty(FurnitureName.Text) || String.IsNullOrEmpty(Model.Text) || String.IsNullOrEmpty(ModelPrice.Text) || String.IsNullOrEmpty(cmbSpecificationsModel.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены!");
            }
            else
            {
                // Проверка на наличие данных в БД
                /*if (ConnectHelper.FurnitureOBJ.Model.Where(u => u.FurnitureName == FurnitureName.Text && u.Model1 == Model.Text && u.ModelPrice == Decimal.Parse(ModelPrice.Text) && u.SpecificationsModel.idSpecificationsModel == Int32.Parse(cmbSpecificationsModel.SelectedValue.ToString())).FirstOrDefault() != null)
                {
                    MessageBox.Show("Такая модель мебели уже есть!");
                }
                else
                {*/
                Model model = new Model()
                {
                    FurnitureName = FurnitureName.Text,
                    Model1 = Model.Text,
                    ModelPrice = decimal.Parse(ModelPrice.Text),
                    idSpecificationsModel = int.Parse(cmbSpecificationsModel.SelectedValue.ToString())
                };
                ConnectHelper.FurnitureOBJ.Model.Add(model); // Добавление данных в таблицу "Model"
                ConnectHelper.FurnitureOBJ.SaveChanges();
                MessageBox.Show("Данные успешно добавлены");
                //}
            }
        }
    }
}
