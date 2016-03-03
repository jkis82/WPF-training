using System;
using System.Collections.ObjectModel;
using System.Timers;
using System.Windows;

namespace OneWayBinding
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      private Timer                          _timer    = new Timer();
      private ObservableCollection<Employee> _employees;

      public MainWindow()
      {
         InitializeComponent();
         DataContext = _employees = Employee.GetEmployees();

         _timer.Interval  = 1000;
         _timer.AutoReset = false;
         _timer.Elapsed  += TimerOnElapsed;
         _timer.Start();
      }

      private void TimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
      {
         CmbEmployees.Dispatcher.Invoke(new Action(() => CmbEmployees.SelectedIndex = 0));
      }
   }
}
