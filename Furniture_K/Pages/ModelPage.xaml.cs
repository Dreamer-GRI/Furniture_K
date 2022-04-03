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
    /// Логика взаимодействия для ModelPage.xaml
    /// </summary>
    public partial class ModelPage : Page
    {
        public ModelPage()
        {
            InitializeComponent();
            dgModel.ItemsSource = ConnectHelper.FurnitureOBJ.Model.ToList(); // Берёт данные из таблицы "Model"
            cmbFilt.SelectedValuePath = "idSpecificationsModel";
            cmbFilt.DisplayMemberPath = "SpecificationsModel1";
            cmbFilt.ItemsSource = ConnectHelper.FurnitureOBJ.SpecificationsModel.ToList();
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
        private void btnAddModel_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.FrameOBJ.Navigate(new ModelAddPage());
        }
               
         // ////////////// //
        // Редактирование //
       // ////////////// //
        private void btnEditModel_Click(object sender, RoutedEventArgs e)
        {
            Model model = dgModel.SelectedItem as Model;
            if (model == null)
            {
                MessageBox.Show("Модель мебели не выбрана");
            }
            else
            {
                FrameApp.FrameOBJ.Navigate(new ModelEditPage(model));
            }
        }

         // ////////// //
        // Фильтрация //
       // ////////// //
        private void cmbFilt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int ModelID = (int)cmbFilt.SelectedValue;
            dgModel.ItemsSource = ConnectHelper.FurnitureOBJ.Model.Where(x => x.idSpecificationsModel == ModelID).ToList();
        }
    }
}
