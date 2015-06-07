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
using domaci2.Controls;


namespace domaci2
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.AddL.Click += AddL_Click;
            this.AddR.Click += AddR_Click;

            RegisterUserDelete();
            RegisterPostDelete();

            RegisterUserEdit();
            RegisterPostEdit();
        }

        void AddR_Click(object sender, RoutedEventArgs e)
        {
            Post prijatelj = new Post();
            prijatelj.Ime = "new friend";
            prijatelj.Status = "new status";
            this.PostContainer.Children.Add(prijatelj);
        }

        void AddL_Click(object sender, RoutedEventArgs e)
        {
            User korisnik = new User();
            korisnik.Title = "new user";
            this.UserContainer.Children.Add(korisnik);
        }

        private void RegisterUserDelete()
        {
            foreach (var child in this.UserContainer.Children)
            {
                if (child is User)
                {
                    var user = (User)child;
                    user.Delete += user_Delete;
                }
            }

            foreach (var child in this.MainUser.Children)
            {
                if (child is User)
                {
                    var user = (User)child;
                    user.Delete += user_Delete;
                }
            }
        }

        void user_Delete(object sender, RoutedEventArgs e)
        {
            if (!(sender is User))
            {
                return;
            }

            var user = (User)sender;
            this.UserContainer.Children.Remove(user);
            this.MainUser.Children.Remove(user);
        }



        private void RegisterUserEdit()
        {
            foreach(var child in this.UserContainer.Children)
            {
                if (child is User)
                {
                    var user = (User)child;
                    user.Edit += user_Edit;
                }
            }

            foreach (var child in this.MainUser.Children)
            {
                if (child is User)
                {
                    var user = (User)child;
                    user.Edit += user_Edit;
                }
            }
        }

        void user_Edit(object sender, RoutedEventArgs e)
        {
            var user = (User)sender;
            user.Title = "novo ime ";
        }

        private void RegisterPostEdit()
        {
            foreach (var child in this.PostContainer.Children)
            {
                if (child is Post)
                {
                    var post = (Post)child;
                    post.Edit += post_Edit;
                }
            }
        }

        void post_Edit(object sender, RoutedEventArgs e)
        {
            var post = (Post)sender;
            // ne znam kako da se ponovno tu upise neko ime i status
            post.Ime = " novo ime";
            post.Status = "novi status ";
        }

        private void RegisterPostDelete()
        {
            foreach (var child in this.PostContainer.Children)
            {
                if (child is Post)
                {
                    var post = (Post)child;
                    post.Delete += post_Delete;
                }
            }
        }

       void post_Delete(object sender, RoutedEventArgs e)
        {
            if (!(sender is Post))
            {
                return;
            }

            var post = (Post)sender;
            this.PostContainer.Children.Remove(post);
        }


    }
}
