using System;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;

namespace JustWpf
{
    public partial class MainWindow : Window
    {
        AppContext db;

        public MainWindow()
        {
            InitializeComponent();

            db = new AppContext();
        }

        private async void RegEnterBut(object sender, RoutedEventArgs e)
        {
            
            using (var db = new AppContext())
            {
                try
                {
                    if ((string)RegisEnterSwitcher_Button.Content == "Войти")
                    {
                        
                        var user = await db.Users
                        .FirstOrDefaultAsync(u => u.Login == textLogin.Text &&
                                                  u.Password == firstPassBox.Password);
                        if (user != null)
                        {
                            EnterNewPage();
                        }
                        else
                        {
                            RedSwitch();
                        }

                    }
                    else
                    {
                        if (textLogin.Text.Length > 3 && firstPassBox.Password.Length > 3 && firstPassBox.Password == SecondPassBox.Password && EmailBox.Text.Length > 3)
                        {
                            User u = new(textLogin.Text, firstPassBox.Password, EmailBox.Text);
                            await db.AddAsync(u);
                            await db.SaveChangesAsync();
                        }
                        else
                            RedSwitch();
                        
                    }
                   
                    
                }
                catch (DbUpdateException dbEx)
                {
                    MessageBox.Show($"Ошибка базы данных: {dbEx.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            }
        }


        public void RedSwitch()
        {
            textLogin.Foreground = Brushes.Red;
            firstPassBox.Foreground = Brushes.Red;
            SecondPassBox.Foreground = Brushes.Red;
            EmailBox.Foreground = Brushes.Red;
        }
        public void WhiteSwitch(object sender,RoutedEventArgs e)
        {
            textLogin.Foreground = Brushes.Black;
            firstPassBox.Foreground = Brushes.Black;
            SecondPassBox.Foreground = Brushes.Black;
            EmailBox.Foreground = Brushes.Black;
        }

        private void RegisEnterSwitcher(object sender, RoutedEventArgs e)
        {
            Button? b = sender as Button;

            if (b?.Name == "Regis")
            {
                SecondPassBox.Visibility = Visibility.Visible;
                EmailBox.Visibility = Visibility.Visible;
                RegisEnterSwitcher_Button.Content = "Зарегистирироваться";
            }
            else
            {
                
                
                SecondPassBox.Visibility = Visibility.Collapsed;
                EmailBox.Visibility = Visibility.Collapsed;
                RegisEnterSwitcher_Button.Content = "Войти";
            }
            
        }

        private void EnterNewPage()
        {
            UserCab u = new UserCab();
            u.Show();
            Hide();
        }

        
    }
}

