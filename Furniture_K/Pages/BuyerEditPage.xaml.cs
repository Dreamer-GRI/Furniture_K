﻿using System;
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
    /// Логика взаимодействия для BuyerEditPage.xaml
    /// </summary>
    public partial class BuyerEditPage : Page
    {
        private Buyer br = new Buyer();
        public BuyerEditPage(Buyer buyer) // Вписываем название таблицы и задаём новую переменную
        {
            InitializeComponent();
            br = buyer;

            FIO.Text = br.NameBuyer;
            Address.Text = br.Address;
            Phone.Text = br.Phone;
        }

         // //////////////////////////// //
        // Возвращене в таблицу "Buyer" //
       // //////////////////////////// //
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.FrameOBJ.Navigate(new Pages.BuyerPage());
        }

         // ///////////////////// //
        // Редактирование данных //
       // ///////////////////// //
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            br.NameBuyer = FIO.Text;
            br.Address = Address.Text;
            br.Phone = Phone.Text; 

            if(br.idBuyer == 0)
            {
                ConnectHelper.FurnitureOBJ.Buyer.Add(br);
            }

            try
            {
                ConnectHelper.FurnitureOBJ.SaveChanges();
                MessageBox.Show("Данные успешно изменены");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
