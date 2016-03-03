using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Controls
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         // One change to prevent fast-forward
         InitializeComponent();
      }

      private void BtnSave_Click(object sender, RoutedEventArgs e)
      {
         StringBuilder SB = new StringBuilder();

         SB.AppendLine("FullName = " + FullName.Text);
         SB.AppendLine("Sex = " + ((bool)Male.IsChecked ? "Male" : "Female"));
         SB.Append("You own = ");
         SB.Append((bool)Desktop.IsChecked ? "Desktop " : string.Empty);
         SB.Append((bool)Laptop.IsChecked ? "Laptop" : string.Empty);
         SB.Append((bool)Tablet.IsChecked ? "Tablet " : string.Empty);
         SB.AppendLine();

         SB.AppendLine("Your profession = " + SelectedProfession(Profession));
         SB.AppendLine("Delivery date = " + DeliveryDate.SelectedDate);

         MessageBox.Show(SB.ToString(), "Saved");
      }

      private string SelectedProfession(ComboBox CB)
      {
         if (CB.SelectedIndex < 0)
            return "None selected";

         ComboBoxItem CBI = CB.SelectedItem as ComboBoxItem;

         return CBI.Content.ToString();
      }
   }
}
