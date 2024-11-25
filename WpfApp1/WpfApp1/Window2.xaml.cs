using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        ExamEntities db = new ExamEntities();
        public Window2()
        {
            InitializeComponent();
            LoadData();
            LoadData2();
        }

        private void LoadData()
        {
            P_I_DG.ItemsSource = db.Tasks.Where(x => x.Status == "Pending" || x.Status == "In Progress").ToList();
        }

        private void LoadData2()
        {
            ComDG.ItemsSource = db.Tasks.Where(x => x.Status == "Completed").ToList();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (P_I_DG.SelectedItem is Task SelectedTask)
            {
                SelectedTask.TaskID = int.Parse(TaskTxT.Text);
                SelectedTask.Status = StatusBox.Text;
                db.SaveChanges();
                LoadData();
            }

        }

        private void P_I_DG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (P_I_DG.SelectedItem is Task SelectedTask)
            {
                TaskTxT.Text = SelectedTask.TaskID.ToString();
                StatusBox.Text = SelectedTask.Status;
            }
            else
            {
                MessageBox.Show("unselectable");
            }
        }

        private void ComDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComDG.SelectedItem is Task SelectedTask)
            {
                TaskTxT.Text = SelectedTask.TaskID.ToString();
                StatusBox.Text = SelectedTask.Status;
            }
            else
            {
                MessageBox.Show("unselectable");
            }
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
            LoadData2();
        }
    }
}
