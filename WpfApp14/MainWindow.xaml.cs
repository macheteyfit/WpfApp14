using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.ComponentModel;

namespace WpfApp14
{
    class Dog : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Dog() { }

        public event PropertyChangedEventHandler PropertyChanged;

        public void onPropertyChanged(string prop)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        


        private int titleNumber = 0;

        public MainWindow()
        {
            InitializeComponent();
            Binding binding = new Binding();
            binding.ElementName = "myTextBox1";
            binding.Path = new PropertyPath("Text");
            myTextBlock.SetBinding(TextBlock.TextProperty, binding);
            buttonRemoveBinding.Click += buttonRemoveBinding_Click;
            ButtonChangeTitle.Click += ButtonChangeTitle_Click;
            buttonChangeName.Click += buttonChangeName_Click;
        }

        private void ButtonChangeTitle_Click(object sender, RoutedEventArgs e)
        {
            titleNumber++;
            Title = $"Title {titleNumber}";
        }

        private void buttonRemoveBinding_Click(object sender, RoutedEventArgs e)
        {
            BindingOperations.ClearAllBindings(myTextBlock1);
        }

        private void buttonChangeName_Click(object sender, RoutedEventArgs e)
        {
            Dog myDog = (Dog)this.Resources["myDog"];
            myDog.Name = "Bolt";
            myDog.onPropertyChanged("Name");
        }
    }
}





