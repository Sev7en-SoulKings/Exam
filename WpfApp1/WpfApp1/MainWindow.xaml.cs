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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ExamEntities db = new ExamEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTxT.Text;
            string password = PasswordTxT.Password;
            var user = db.Users.FirstOrDefault(u => u.Name == username && u.Password == password);
            if (user.Role != null)
            {
                if (RoleTxT.Text == "Manager")
                {
                    Window1 window1 = new Window1();
                    window1.Show();
                    this.Close();
                    MessageTxTBlock.Text = "Welcome";

                }

                else if (RoleTxT.Text == "Employee")
                {
                    Window2 window2 = new Window2();
                    window2.Show();
                    this.Close();
                    MessageTxTBlock.Text = "Welcome";
                }
                else
                {
                    MessageTxTBlock.Text = "Invalid Role";
                }
            }
        }
    }
}
