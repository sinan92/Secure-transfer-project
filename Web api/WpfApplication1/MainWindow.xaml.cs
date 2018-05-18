using BasicSecurity.Data.DomainClasses;
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
using BasicSecurity.Models;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Person person = new Person();

            person.Password = "hoi123";

            var password = person.Password;
            var help = PasswordHash.HashPassword(password);
            var help2 = help.Split(':');
            var hash = help2[2];
            var salt = help2[1];

            person.Password = hash;
            person.Salt = salt;

            MessageBox.Show(person.Password + " + " + person.Salt);
        }
    }
}
