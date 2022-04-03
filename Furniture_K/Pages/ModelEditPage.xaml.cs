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
    /// Логика взаимодействия для ModelEditPage.xaml
    /// </summary>
    public partial class ModelEditPage : Page
    {
        private Model md = new Model();
        public ModelEditPage(Model model)
        {
            InitializeComponent();
            cmbSpecificationsModel.SelectedValuePath = "idSpecificationsModel";
            cmbSpecificationsModel.DisplayMemberPath = "SpecificationsModel1";
            cmbSpecificationsModel.ItemsSource = ConnectHelper.FurnitureOBJ.SpecificationsModel.ToList();

            md = model;

            FurnitureName.Text = md.FurnitureName;
            Model.Text = md.Model1;
            ModelPrice.Text = md.ModelPrice.ToString();
            cmbSpecificationsModel.Text = md.SpecificationsModel.SpecificationsModel1;
        }

         // ///////////////////// //
        // Редактирование данных //
       // ///////////////////// //
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            md.FurnitureName = FurnitureName.Text;
            md.Model1 = Model.Text;
            md.ModelPrice = decimal.Parse(ModelPrice.Text);
            md.idSpecificationsModel = int.Parse(cmbSpecificationsModel.SelectedValue.ToString());

            if (md.idModel == 0)
            {
                ConnectHelper.FurnitureOBJ.Model.Add(md);
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

         // //////////////////////////// //
        // Возвращене в таблицу "Model" //
       // //////////////////////////// //
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.FrameOBJ.Navigate(new Pages.ModelPage());
        }
    }
}
