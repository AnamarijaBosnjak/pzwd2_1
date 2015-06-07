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
    /// Interaction logic for Post.xaml
    /// </summary>
    public partial class Post : UserControl
    {
        public Post()
        {
            InitializeComponent();
            this.DeleteIcon.MouseDown += new MouseButtonEventHandler(DeleteIcon_MouseDown);
            this.EditIcon.MouseDown += new MouseButtonEventHandler(EditIcon_MouseDown);
        }
        public string Ime
        {
            get { return (string)GetValue(ImeProperty); }
            set { SetValue(ImeProperty, value); }
        }

        public static readonly DependencyProperty ImeProperty = DependencyProperty.Register
        (
            "Ime",
            typeof(string),
            typeof(Post),
            new UIPropertyMetadata("Ime")
        );


        public string Status
        {
            get { return (string)GetValue(StatusProperty); }
            set { SetValue(StatusProperty, value); }
        }

        public static readonly DependencyProperty StatusProperty = DependencyProperty.Register
        (
            "Status",
            typeof(string),
            typeof(Post),
            new UIPropertyMetadata("Status")
        );

        public static readonly RoutedEvent DeleteEvent = EventManager.RegisterRoutedEvent
         (
            "Delete", 
             RoutingStrategy.Bubble,
             typeof(RoutedEventHandler),
             typeof(Post) 
         );
        public event RoutedEventHandler Delete 
        {
            add { AddHandler(DeleteEvent, value); }
            remove { RemoveHandler(DeleteEvent, value); }
        }

        void RaiseDeleteEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(Post.DeleteEvent);
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
            typeof(Post)
        );

        public event RoutedEventHandler Edit
        {
            add { AddHandler(EditEvent, value); }
            remove { RemoveHandler(EditEvent, value); }
        }

        void RaiseEditEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(Post.EditEvent);
            RaiseEvent(newEventArgs);
        }

        void EditIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RaiseEditEvent();
        }

        
    }
}
