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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        ExamEntities db = new ExamEntities();
        Task t = new Task();

        public Window1()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            EmpDG.ItemsSource = db.Tasks.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var Task = new Task()
            {
                UserID = int.Parse(UserIDTxT.Text),
                TaskID = int.Parse(TaskIDTxT.Text),
                Title = TitleTxT.Text,
                Description = DesTxT.Text,
                Status = StatusCBox.Text,
            };
            db.Tasks.Add(Task);
            db.SaveChanges();
            LoadData();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EmpDG.SelectedItem is Task SelectedTask)
            {
                SelectedTask.UserID = int.Parse(UserIDTxT.Text);
                SelectedTask.TaskID = int.Parse(TaskIDTxT.Text);
                SelectedTask.Title = TitleTxT.Text;
                SelectedTask.Description = DesTxT.Text;
                SelectedTask.Status = StatusCBox.Text;
                db.SaveChanges();
                LoadData();
            }

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

            if (EmpDG.SelectedItem is Task SelectedTask)
            {
                db.Tasks.Remove(SelectedTask);
                db.SaveChanges();
                LoadData();
            }

        }

        private void EmpDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmpDG.SelectedItem is Task SelectedTask)
            {
                UserIDTxT.Text = SelectedTask.UserID.ToString();
                TaskIDTxT.Text = SelectedTask.TaskID.ToString();
                TitleTxT.Text = SelectedTask.Title;
                DesTxT.Text = SelectedTask.Description;
                StatusCBox.Text = SelectedTask.Status;
            }
            else
            {
                MessageBox.Show("unselectable");
            }
        }
    }
}
