using System.Timers;
using System.Windows;

namespace OneWayBinding
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      private Employee _employee = new Employee() {Name = "John", Title = "Programmer"};
      private Timer    _timer    = new Timer();

      public MainWindow()
      {
         InitializeComponent();
         DataContext = _employee;

         _timer.Interval  = 1000;
         _timer.AutoReset = false;
         _timer.Elapsed  += TimerOnElapsed;
         _timer.Start();
      }

      private void TimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
      {
         _employee.Title = "Timer timeout";
      }
   }
}
