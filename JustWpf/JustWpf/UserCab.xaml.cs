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

namespace JustWpf
{
    /// <summary>
    /// Логика взаимодействия для UserCab.xaml
    /// </summary>
    public partial class UserCab : Window
    {
        public UserCab()
        {
            InitializeComponent();

            AppContext appContext = new AppContext();
            List<User> users = appContext.Users.ToList();

            listOfUsers.ItemsSource = users;

        }
    }
}
