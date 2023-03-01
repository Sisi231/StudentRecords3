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

namespace StudentRecords
{
    /// <summary>
    /// Interaction logic for SingUp.xaml
    /// </summary>
    public partial class SingUp : Window
    {
        public SingUp()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Opening OpenOpening = new Opening();
            OpenOpening.Show();
            this.Close();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Password.Length < 10 || PasswordBox.Password.Length > 10)
            {
                MessageBox.Show("Your password should be at least 10 symbols long! Try again");
            }
            else if (txtFirstName.Text.Equals(""))
            {
                MessageBox.Show("You cannot leave this field empty!");
            }
            else if (txtLastName.Text.Equals(""))
            {
                MessageBox.Show("You cannot leave this field empty!");
            }
            else if (txtUsername.Text.Equals(""))
            {
                MessageBox.Show("You cannot leave this field empty!");
            }
            else if (!txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("You cannot have an email without '@'!");
            }
            else if (!(PasswordBox.Password == RePasswordBox.Password))
            {
                MessageBox.Show("The passwords don't match!Try again.");
            }
            else
            {
                Opening OpenOpening = new Opening();
            OpenOpening.Show();
            this.Close();
            }
        }
    }
}
