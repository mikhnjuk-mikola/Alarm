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

namespace Калькулятор
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //string leftop = ""; 
        //string operation = ""; 
        //string rightop = ""; 
 
    
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

       
    public  static void Digits(object sender, ExecutedRoutedEventArgs e)
        {

            string s = (string)((Button)e.OriginalSource).Content;
           TextBox1.Text += s;
            
        }
        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    TextBox1.Clear();
        //}
        
    }
    //public class Digit
    //{
    //    static Digit()
    //    {
    //        ClickDigitComand = new RoutedCommand("Digit", typeof(MainWindow));
    //    }
    //    public static RoutedCommand ClickDigitComand { get; set; }
    //}
}

