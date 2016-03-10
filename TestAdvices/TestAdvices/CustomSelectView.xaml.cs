using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace TestAdvices
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class CustomSelectView : Window
   {
      public CustomSelectView()
      {
         InitializeComponent();
      }

      private void ButtonImage_Loaded(object sender, RoutedEventArgs e)
      {
         string resDir = Path.Combine(Directory.GetCurrentDirectory(), "Resources");
         
         // ... Create a new BitmapImage.
         BitmapImage b = new BitmapImage();
         b.BeginInit();
         b.UriSource = new Uri(Path.Combine(resDir, "ComboxboxArrow.gif"));
         b.EndInit();

         // ... Get Image reference from sender.
         var image = sender as System.Windows.Controls.Image;
         // ... Assign Source.
         image.Source = b;
      }
   }
}
