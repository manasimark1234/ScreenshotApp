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
using System.Drawing;

namespace ScreenshotApp
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

        private void save_Screenshot_as_File()
        {
            try
            {
                Random random = new Random();
                int length = 6;
                const string chars = "123456789abcdefghijklmnopqrstuvwxyz";
                var pass = new string(Enumerable.Repeat(chars, length)
                  .Select(s => s[random.Next(s.Length)]).ToArray());

                string filename = "ScreenShot-" + pass + ".png";

                int screenLeft = (int)SystemParameters.VirtualScreenLeft;
                int screenTop = (int)SystemParameters.VirtualScreenTop;
                int screenWidth = (int)SystemParameters.VirtualScreenWidth;
                int screenHeight = (int)SystemParameters.VirtualScreenHeight;

                Bitmap bitmap_Screen = new Bitmap(screenWidth, screenHeight);
                Graphics g = Graphics.FromImage(bitmap_Screen);

                g.CopyFromScreen(screenLeft, screenTop, 0, 0, bitmap_Screen.Size);

                bitmap_Screen.Save("C:\\Users\\m.pravin.markandeya\\Desktop\\AppScreenshorts\\" + filename);
            }
            catch(Exception ex)
            {
                throw ex;
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            save_Screenshot_as_File();
        }

        private void Windows_Keydown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.P)
            {
                save_Screenshot_as_File();
            }
        }
    }
}
