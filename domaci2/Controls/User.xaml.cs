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

namespace domaci2.Controls
{
    /// <summary>
    /// Interaction logic for User.xaml
    /// </summary>
    public partial class User : UserControl
    {
        public User()
        {
            InitializeComponent();
            this.DeleteIcon.MouseDown += new MouseButtonEventHandler(DeleteIcon_MouseDown);
            this.EditIcon.MouseDown += new MouseButtonEventHandler(EditIcon_MouseDown);
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register
        (
            "Title",
            typeof(string),
            typeof(User),
            new UIPropertyMetadata("Title")
        );


         public static readonly RoutedEvent DeleteEvent = EventManager.RegisterRoutedEvent
         (
            "Delete", //ime eventa
             RoutingStrategy.Bubble,
             typeof(RoutedEventHandler),
             typeof(User) //tip elementa koji posjeduje event
         );
        public event RoutedEventHandler Delete //za registraciju/deregistraciju 
        {
            add { AddHandler(DeleteEvent, value); }
            remove { RemoveHandler(DeleteEvent, value); }
        }

        void RaiseDeleteEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(User.DeleteEvent);
            RaiseEvent(newEventArgs);
        }


        void DeleteIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RaiseDeleteEvent();
        }

        public static readonly RoutedEvent EditEvent = EventManager.RegisterRoutedEvent
        (
           "Edit",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(User)
        );

        public event RoutedEventHandler Edit
        {
            add { AddHandler(EditEvent, value); }
            remove { RemoveHandler(EditEvent, value); }
        }

        void RaiseEditEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(User.EditEvent);
            RaiseEvent(newEventArgs);
        }

        void EditIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RaiseEditEvent();
        }

    }
}
