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

namespace Lab02_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            cboSemester.ItemsSource = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8" };

            lstCourses.ItemsSource = new List<string> { "COMP100", "COMP213", "COMP120", "COMP125", "COMP123", "COMP122", "MATH185", "COMM171" };

        }

        

        

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cboSemester.SelectedIndex = 1;
            txtName.Text = "Gabriel De Marchi";

            lstCourses.UnselectAll();

            rbtnDomestic.IsChecked = true;
              
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            string result;

            result = "Name: " + txtName.Text + "Semester: " ;

           result = cboSemester.Text + "\n Nationality: " ;

           result = (rbtnDomestic.IsChecked ?? true) ? " DOMESTIC ":" INTERNATIONAL " + " Courses: ";

            foreach (string item in lstCourses.SelectedItems)
            {
                 result += item + ", " ;
            }

            MessageBox.Show(result, "User Data", MessageBoxButton.OK);

        }
    }
}
