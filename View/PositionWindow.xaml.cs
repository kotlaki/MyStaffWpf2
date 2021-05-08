using MyStaffWpf2.ViewModel;
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
using System.Windows.Shapes;

namespace MyStaffWpf2.View
{
    /// <summary>
    /// Логика взаимодействия для PositionWindow.xaml
    /// </summary>
    public partial class PositionWindow : Window
    {
        public static ListView AllPositions;

        public PositionWindow()
        {
            InitializeComponent();

            DataContext = new DateManageVM();

            AllPositions = viewAllPos;


        }

        private void Button_Refresh_Click(object sender, RoutedEventArgs e)
        {
       /*     this.Close();
            PositionWindow positionWindow = new PositionWindow();
            positionWindow.Show();
       */
        }
    }
}
