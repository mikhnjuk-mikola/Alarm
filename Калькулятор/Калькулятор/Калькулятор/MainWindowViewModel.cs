using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;


namespace Калькулятор
{
    public class MainWindowViewModel : DependencyObject
    {
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(MainWindowViewModel));


        public MainWindowViewModel()
        {
            PlusCommand = new RelayCommand(PlusCommandExecute);
            MultiplicetionCommand = new RelayCommand(MultiplicetionCommandExecute);
            SubtractionCommand = new RelayCommand(SubtractionCommandExecute);
            DivisionCommand = new RelayCommand(DivisionCommandExecute);
            ProcentCommand = new RelayCommand(ProcentCommandExecute);
            ResultCommand = new RelayCommand(ResultCommandExecute);
            DigitCommand = new RelayCommand(DigitCommandExecute);


        }

        private void DigitCommandExecute(object obj)
        {
            
           
        }
        private void ResultCommandExecute(object obj)
        {
            Value = 15;
        }
        private void ProcentCommandExecute(object obj)
        {
            Value=14;
        }
        private void DivisionCommandExecute(object obj)
        {
            Value = 13;
        }
        private void MultiplicetionCommandExecute(object obj)
        {
            Value = 11;
        }
        private void PlusCommandExecute(object obj)
        {
            Value = 10;
        }
        private void SubtractionCommandExecute(object obj)
        {
            Value = 12;
        }
        public RelayCommand ResultCommand
        {
            get { return (RelayCommand)GetValue(ResultCommandProperty); }
            set { SetValue(ResultCommandProperty, value); }
        }
        public RelayCommand DigitCommand
        {
            get { return (RelayCommand)GetValue(DigitCommandProperty); }
            set { SetValue(DigitCommandProperty, value); }
        }
        public RelayCommand ProcentCommand
        {
            get { return (RelayCommand)GetValue(ProcentCommandProperty); }
            set { SetValue(ProcentCommandProperty, value); }
        }
        public RelayCommand PlusCommand
        {
            get { return (RelayCommand)GetValue(PlusCommandProperty); }
            set { SetValue(PlusCommandProperty, value); }
        }
        public RelayCommand DivisionCommand
        {
            get { return (RelayCommand)GetValue(DivisionCommandProperty); }
            set { SetValue(DivisionCommandProperty, value); }
        }
        public RelayCommand SubtractionCommand
        {
            get { return (RelayCommand)GetValue(SubtractionCommandProperty); }
            set { SetValue(SubtractionCommandProperty, value); }
        }
        public RelayCommand MultiplicetionCommand
        {
            get { return (RelayCommand)GetValue(MultiplicetionCommandProperty); }
            set { SetValue(MultiplicetionCommandProperty, value); }
        }        
        public static readonly DependencyProperty PlusCommandProperty =
            DependencyProperty.Register("PlusCommand", typeof(RelayCommand), typeof(MainWindowViewModel));
        public static readonly DependencyProperty MultiplicetionCommandProperty =
            DependencyProperty.Register("MultiplicetionCommand", typeof(RelayCommand), typeof(MainWindowViewModel));
        public static readonly DependencyProperty SubtractionCommandProperty =
              DependencyProperty.Register("SubtractionCommand", typeof(RelayCommand), typeof(MainWindowViewModel));
        public static readonly DependencyProperty DivisionCommandProperty =
                DependencyProperty.Register("DivisionCommand", typeof(RelayCommand), typeof(MainWindowViewModel));

        public static readonly DependencyProperty ProcentCommandProperty =
               DependencyProperty.Register("ProcentCommand", typeof(RelayCommand), typeof(MainWindowViewModel));

        public static readonly DependencyProperty ResultCommandProperty =
              DependencyProperty.Register("ResultCommand", typeof(RelayCommand), typeof(MainWindowViewModel));
        public static readonly DependencyProperty DigitCommandProperty =
                DependencyProperty.Register("DigitCommand", typeof(RelayCommand), typeof(MainWindowViewModel));
      


              

    }
}
