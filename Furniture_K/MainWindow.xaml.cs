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
using Furniture_K.Classes; // Использую папку "Classes" для "MainWindow" //

namespace Furniture_K
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameApp.FrameOBJ = MainFrame; // Используем класс Frame в MainWindow //
            ConnectHelper.FurnitureOBJ = new FurnitureEntities(); // Строка подключения БД для MainWindow //
        }
    }
}
