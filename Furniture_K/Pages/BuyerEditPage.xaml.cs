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
    /// Логика взаимодействия для BuyerEditPage.xaml
    /// </summary>
    public partial class BuyerEditPage : Page
    {
        public BuyerEditPage(Buyer buyer)
        {
            InitializeComponent();
            FIO.Text = buyer.NameBuyer;
        }
    }
}
