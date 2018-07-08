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
using VkNet;
using VkNet.Enums.Filters;
using VkPick.Utils;


namespace VkPick
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static VkApi _api;
        public MainWindow()
        {
            InitializeComponent();
            _frame = MainFrame;

            
        }

        private static Frame _frame;
        public static void GoPage(Page page)
        {
            MainWindow._frame.NavigationService.Navigate(page);
        }
    }
}
