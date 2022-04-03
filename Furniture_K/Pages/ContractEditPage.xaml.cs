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
    /// Логика взаимодействия для ContractEditPage.xaml
    /// </summary>
    public partial class ContractEditPage : Page
    {
        private Contract cr = new Contract();
        public ContractEditPage(Contract contract)
        {
            InitializeComponent();
            cmbNameBuyer.SelectedValuePath = "idBuyer";
            cmbNameBuyer.DisplayMemberPath = "NameBuyer";
            cmbNameBuyer.ItemsSource = ConnectHelper.FurnitureOBJ.Buyer.ToList();

            cr = contract;

            ContractNumber.Text = cr.ContractNumber.ToString();
            RegistrationDate.Text = cr.RegistrationDate.ToString();
            DateOfExecution.Text = cr.DateOfExecution.ToString();
            cmbNameBuyer.Text = cr.Buyer.NameBuyer;
        }

         // /////////////////////////////// //
        // Возвращене в таблицу "Contract" //
       // /////////////////////////////// //
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.FrameOBJ.Navigate(new Pages.ContractPage());
        }

         // ///////////////////// //
        // Редактирование данных //
       // ///////////////////// //
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            cr.ContractNumber = int.Parse(ContractNumber.Text);
            cr.RegistrationDate = DateTime.Parse(RegistrationDate.Text);
            cr.DateOfExecution = DateTime.Parse(DateOfExecution.Text);
            cr.idBuyer = int.Parse(cmbNameBuyer.SelectedValue.ToString());

            if (cr.idConttract == 0)
            {
                ConnectHelper.FurnitureOBJ.Contract.Add(cr);
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
    }
}
