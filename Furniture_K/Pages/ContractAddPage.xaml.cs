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
    /// Логика взаимодействия для ContractAddPage.xaml
    /// </summary>
    public partial class ContractAddPage : Page
    {
        public ContractAddPage()
        {
            InitializeComponent();
            cmbNameBuyer.SelectedValuePath = "idBuyer";
            cmbNameBuyer.DisplayMemberPath = "NameBuyer";
            cmbNameBuyer.ItemsSource = ConnectHelper.FurnitureOBJ.Buyer.ToList();
        }

         // ///////////////// //
        // Добавление данных //
       // ///////////////// //
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Проверка на пустое и нулевое значение в полях
            if (String.IsNullOrEmpty(ContractNumber.Text) || String.IsNullOrEmpty(RegistrationDate.Text) || String.IsNullOrEmpty(DateOfExecution.Text) || String.IsNullOrEmpty(cmbNameBuyer.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены!");
            }
            else
            {
                // Проверка на наличие данных в БД
                /*if (ConnectHelper.FurnitureOBJ.Contract.Where(u => u.ContractNumber == int.Parse(ContractNumber.Text) && u.RegistrationDate == DateTime.Parse(DateOfExecution.Text) && u.DateOfExecution == DateTime.Parse(DateOfExecution.Text) && u.Buyer.idBuyer == int.Parse(cmbNameBuyer.SelectedValue.ToString())).FirstOrDefault() != null)
                {
                    MessageBox.Show("Такой контракт уже есть!");
                }
                else
                {*/
                    Contract contract = new Contract()
                    {
                        ContractNumber = int.Parse(ContractNumber.Text),
                        RegistrationDate = DateTime.Parse(RegistrationDate.Text),
                        DateOfExecution = DateTime.Parse(DateOfExecution.Text),
                        idBuyer = int.Parse(cmbNameBuyer.SelectedValue.ToString())
                    };
                    ConnectHelper.FurnitureOBJ.Contract.Add(contract); // Добавление данных в таблицу "Contract"
                    ConnectHelper.FurnitureOBJ.SaveChanges();
                    MessageBox.Show("Данные успешно добавлены");
                //}
            }
        }

         // /////////////////////////////// //
        // Возвращене в таблицу "Contract" //
       // /////////////////////////////// //
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.FrameOBJ.Navigate(new Pages.ContractPage());
        }
    }
}
