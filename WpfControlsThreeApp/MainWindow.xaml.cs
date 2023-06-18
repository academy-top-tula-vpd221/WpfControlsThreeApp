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

namespace WpfControlsThreeApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    class User
    {
        public string Name { get; set; }
        public int Age { set; get; }
        public bool IsAdmin { set; get; }
        public override string ToString()
        {
            string role = (IsAdmin ? "Admin" : "Member");
            return $"Name: {Name}, Age: {Age}, Role: {role}";
        }
    }
    public partial class MainWindow : Window
    {
        List<User> users = new List<User>()
        {
            new(){ Name = "Tonny", Age = 32, IsAdmin = true },
            new(){ Name = "Bob", Age = 28, IsAdmin = false },
            new(){ Name = "Peet", Age = 19, IsAdmin = false },
            new(){ Name = "Tommy", Age = 32, IsAdmin = true },
            new(){ Name = "Jim", Age = 24, IsAdmin = false },
            new(){ Name = "Tim", Age = 32, IsAdmin = true },
        };

        public MainWindow()
        {
            InitializeComponent();

            list1.Items.Add("Item 4");
            list1.Items.Insert(2, "Item 5");

            listUsers.ItemsSource = users;
            users.Add(new() { Name = "Sam", Age=28, IsAdmin = false });
            comboUsers.ItemsSource = users;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            MessageBox.Show("Hello " + name);
        }

        private void psw_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if(psw.Password.Length < 8) 
            { 
                txtError.Visibility = Visibility.Visible;
            }
            else
                txtError.Visibility = Visibility.Hidden;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            users.Add(new() { Name = "Mike", Age = 31, IsAdmin = true });
            listUsers.Items.Refresh();
        }

        private void listUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // SelectedItem, SelectedIndex, SelectedValue
            //string message = listUsers.SelectedItem.ToString() + "\n";
            //message += listUsers.SelectedIndex.ToString() + " " + listUsers.SelectedValue.ToString();
            //MessageBox.Show(message);

            string message = "";
            foreach(var item in listUsers.SelectedItems) 
            {
                message += item.ToString() + "\n";
            }
            MessageBox.Show(message);
        }

        private void comboUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string message = comboUsers.SelectedItem.ToString() + "\n";
            message += comboUsers.SelectedIndex.ToString() + " " + comboUsers.SelectedValue.ToString();
            MessageBox.Show(message);
        }
    }
}
