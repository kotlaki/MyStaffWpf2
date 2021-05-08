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
    /// Логика взаимодействия для DepartmentWindow.xaml
    /// </summary>
    public partial class DepartmentWindow : Window

    {

        public static ListView AllDepartments;

        public DepartmentWindow()
        {
            InitializeComponent();

            DataContext = new DateManageVM();

            AllDepartments = viewAllDep;


        }

        private void Button_Refresh_Click(object sender, RoutedEventArgs e)
        {

        /*    this.Close();
            DepartmentWindow departmentWindow = new DepartmentWindow();
            departmentWindow.Show();
        */
        }
    }
}
